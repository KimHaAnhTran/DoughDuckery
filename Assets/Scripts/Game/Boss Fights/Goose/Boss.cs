using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    //Setting HP of the boss
    public int bossHP = 40;
    private int halfHP;
    
    //Access a Slider to display the boss' health bar
    public Slider healthBar;

    //See which direction boss is facing
    public bool isFlipped = false;
 
    //Access the position of the player
    public Transform player;

    //Declare private variables
    private Animator anim;
    private bool dead = false;

    //Sound effect for roaring
    [SerializeField] public AudioSource bossRoar;

    
    // Start is called before the first frame update
    void Start()
    {
        //Accessing the animation of the boss
        anim = GetComponent<Animator>();
        halfHP = bossHP / 2;
}

    // Update is called once per frame
    void Update()
    {
        //Set the whole value of the Slider to match the boss' HP
        healthBar.value = bossHP;

        if (bossHP <= halfHP)
        {
            //When boss' health is lower than half, enter phase 2 of boss fight
            //Set boss' animation to "rage"
            anim.SetTrigger("rage");
        }

        if (bossHP <= 0 && !dead)
        {
            //When boss is dead, then play animation "death"
            anim.SetTrigger("death");
            //Set the boss' tag to "collidables" so player wouldn't die if upon contact with boss
            gameObject.tag = "collidables";
            dead = true;
            //Destroy all objects nestled within the boss game object
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            //If boss came in contact with bullets
            //Then HP decrease
            bossHP--;
        }
    }
  
    public void roar()
    {
        //When boss roars, play the sound effect
        bossRoar.Play();
    }

    public void LookAtPlayer()
    {
        //Code for boss to look at the player
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            //If the player is on the left of the boss, and the boss is flipped
            //Then flip the boss to look at player
            transform.localScale = flipped;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            //If the player is on the right of the boss, and the boss isn't flipped
            //Then flip the boss to look at player
            transform.localScale = flipped;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            isFlipped = true;
        }
    }

}
