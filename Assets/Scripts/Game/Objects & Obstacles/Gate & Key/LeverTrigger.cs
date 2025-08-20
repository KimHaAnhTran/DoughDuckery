using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource leverSFX;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            anim.SetTrigger("down");
            leverSFX.Play();
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

        }
    }
}
