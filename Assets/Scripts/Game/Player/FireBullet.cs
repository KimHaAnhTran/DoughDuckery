using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("collidables"))
        {
            bulletSpeed = 0;
            rb.velocity = rb.velocity * bulletSpeed;
            anim.SetTrigger("impact");

        }
        else
        {
            Invoke("destroyObject", 1f);
        }

    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }
}
