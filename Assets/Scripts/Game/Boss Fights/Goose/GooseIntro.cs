using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseIntro : StateMachineBehaviour
{
    private int rand;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("start animation");
        rand = Random.Range(0,2);
        Debug.Log(rand);
        if (rand == 0)
        {
            Debug.Log("idle");
            animator.SetTrigger("idle");
        }
        else
        {
            Debug.Log("walk");
            animator.SetTrigger("walk");
        }
    }

}
