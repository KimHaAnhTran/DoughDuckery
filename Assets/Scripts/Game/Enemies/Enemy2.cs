using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy2 : MonoBehaviour
{
    private float enemyHealth = 5f;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [SerializeField] private AudioSource hitSFX;
    [SerializeField] private AudioSource explodeSFX;


    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            hitSFX.Play();
            enemyHealth--;
            if (enemyHealth <= 0)
            {
                explodeSFX.Play();
                anim.SetTrigger("death");
            }
        }
    }

    public void destroyObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
