using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GooseIdle : StateMachineBehaviour
{
    //Declare variables for time
    public float bossTimer;
    public float minTime;
    public float maxTime;

    //Variable for how far the player is to the boss
    public float attackRange = 3f;

    //Declare private variables of the boss
    private Transform playerPos;
    private Rigidbody2D rb;

    //public Boss gooseBoss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //BossTimer is a random number of seconds before boss changes animation
        //BossTimer is decided by picking a random number of second between minTime and maxTime
        bossTimer = Random.Range(minTime,maxTime);

        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Once bossTimer is 0 (meaning the boss is done standing for x seconds)
        //Then set the animation to walking
        if (bossTimer <= 0)
        {
            animator.SetTrigger("walk");
        }
        else
        {
            //decase bossTimer until it reaches 0
            bossTimer -= Time.deltaTime;
        }

        if (Vector2.Distance(playerPos.position, rb.position) <= attackRange)
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
