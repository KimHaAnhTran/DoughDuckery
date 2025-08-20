using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressor : MonoBehaviour
{
    private Animator anim;
    public GameObject door;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") || collision.gameObject.CompareTag("box"))
        {
            anim.SetTrigger("buttonPressed");
            door.SetActive(false);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") || collision.gameObject.CompareTag("box"))
        {
            anim.ResetTrigger("buttonPressed");
            door.SetActive(true);
            
        }
    }


}
