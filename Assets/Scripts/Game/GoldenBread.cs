using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenBread : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    private GameObject bread;
    public Boss boss;
    public ItemCollector itemCollector;
    public Image breadUI;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    void Update()
    {
        if (boss.bossHP <= 0)
        {
            gameObject.transform.SetParent(null);
            anim.SetTrigger("bossDeath");
            sprite.enabled = true;
        }
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            itemCollector.breads++;
            breadUI.enabled = true;
        }
    }
}
