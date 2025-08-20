using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.U2D;
using Transform = UnityEngine.Transform;

public class GooseWalk : StateMachineBehaviour
{
    //Declare variables for time
    public float bossTimer;
    public float minTime;
    public float maxTime;

    //How fast boss is moving
    public float speed;
    //Variable for how far the player is to the boss
    public float attackRange = 3f;

    //Access the script Boss
    Boss boss;

    //Declare private variables of the boss
    private UnityEngine.Transform playerPos;
    private Rigidbody2D rb;

    //[SerializeField] private UnityEngine.GameObject[] waypoints;
    //private int currentWaypointIndex = 0;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //BossTimer is a random number of seconds before boss changes animation
        //BossTimer is decided by picking a random number of second between minTime and maxTime
        bossTimer = Random.Range(minTime, maxTime);

        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        boss = animator.GetComponent<Boss>();
        rb = animator.GetComponent<Rigidbody2D>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Whenever boss walks, then turn boss to look at player
        boss.LookAtPlayer();

        if (bossTimer <= 0)
        {
            //Once bossTimer is 0 (meaning the boss is done walking for x seconds)
            //Then set the animation to standing
            animator.SetTrigger("idle");
        }
        else
        {
            bossTimer -= Time.deltaTime;
        }

        //Find the position of the player
        Vector2 target = new Vector2(playerPos.position.x,animator.transform.position.y);
        //Make the boss move from its original position towards the player
        animator.transform.position = Vector2.MoveTowards(animator.transform.position,target, speed * Time.deltaTime);

        if (Vector2.Distance(playerPos.position,rb.position) <= attackRange)
        {
            //if the distance between the player and the boss is <= attackRange
            //Then set animation to "attack1"
            animator.SetTrigger("attack1");
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Once the attack animation is done, then reset the trigger which causes it
        animator.ResetTrigger("attack1");
    }

}
