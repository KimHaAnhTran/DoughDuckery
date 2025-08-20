using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSign : MonoBehaviour
{
    public GameObject sign;
    public DialogueBox dialogue;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            sign.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!dialogue.sign)
            {
                dialogue.sign = true;
                dialogue.callDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            sign.SetActive(false);
        }
    }
}
