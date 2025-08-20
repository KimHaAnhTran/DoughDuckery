using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Declaring private variables for the player
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    
    //See if the player is moving or jumping/falling 
    //In which the 0f will turn into -1f or 1f
    private float moveX = 0f;
    private float moveY = 0f;

    //The speed of the player  & jump force
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 6f;

    [SerializeField] private AudioSource jumpSFX;

    //Variable to check for jumpable ground
    [SerializeField] private LayerMask jumpableGround;

    //The amount of jumps a player has (which is only two once they hit the once)
    private float doubleJump = 1f;

    private bool isLadder = false;

    
    //Listing out the four movement states to change between animations
    private enum MovementState { idle, running, jumping, falling}
    
    // Start is called before the first frame update
    private void Start()
    {
        //Getting components from the player character
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Getting X and Y movements of player
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        //Change the x and y position of the player using movespeed
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        //Check if the jump button is held & see if player is on jumpable ground or doublejump is above 0
        if (Input.GetButtonDown("Jump") && (IsGrounded() || doubleJump > 0))
        {
            //Horizontal movement is the same mechanic, but the y position is changed by jumpForce
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //doubleJump would minus until it reaches below 0, so player wouldn't be able to double jump anymore
            doubleJump--;
            //Play sound effect
            jumpSFX.Play();

            //Check to see if player is grounded
            //If yes, then doubleJump of player resets back to 1
            if (IsGrounded())
            {
                doubleJump = 1f;
            }
        }
        if (isLadder)
        {
            //Check to see if player is touching a ladder
            //If yes, then set gravity to 0 (so player can move vertically
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, moveY * moveSpeed);
        }
        else
        {
            //If not, set the player's gravity back to normal
            rb.gravityScale = 1f;
        }

        //Change the appearance of the player depending on what player is doing
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (moveX > 0f)
        {
            //If player is moving to the right
            //Then change player's animation to running
            state = MovementState.running;
            //Turn the player to face the right
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (moveX < 0f)
        {
            //If player is moving to the left
            //Then change player's animation to running
            state = MovementState.running;
            //Turn the player to face the left
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            //If player is not moving (i.e. moveX = 0)
            //Then change player's animation to idle
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.001f)
        {
            //If player's vertical movement is higher than 0.001
            //Then change player's animation to jumping
            state = MovementState.jumping;
        }else if (rb.velocity.y < -0.001f)
        {
            //Else, make the player's animation to falling
            state = MovementState.falling;
        }

        //Access the player's animation tree to change between the state of animations
        //Each animation state is numbered, so I used integer to mark which one instead of using their names
        //"state" is an integer parameter in the animation tree
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        //We create another box around our player that has the same shape as our box collider
        //coll.bounds.center is the box's position (centered around the player)
        //coll.bounds.size is the box's size (same size as the player's box)
        //Vector2.down is the direction the box would move, and .1f is how far the box is moved own (aka just a little bit)

        //The point is to detect if the player's box collider is overlapping with the box collider of the ground
        //If it is overlapping, then return true

        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            //Check if player is in contact with a ladder
            //If yes, then set isLadder to true
            isLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            //Once player is no longer in contact with a ladder
            //Set isLadder to false
            isLadder = false;
        }
    }
}
