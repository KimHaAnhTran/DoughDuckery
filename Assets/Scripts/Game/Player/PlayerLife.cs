using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private bool dead = false;
    public float lives = 3f;

    [SerializeField] private AudioSource deathSFX;
    Vector2 checkpointPos;
    private void Start()
    {
        anim = GetComponent<Animator>();
        checkpointPos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("trap") || collision.gameObject.CompareTag("enemy")) && !dead)
        {
            Die();
        }

        if (collision.gameObject.CompareTag("checkpoint"))
        {
            checkpointPos = transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && !dead)
        {
            Die();
        }
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

    private void Die()
    {
        dead = true;
        anim.SetTrigger("death");
        deathSFX.Play();
    }

    private void Respawn()
    {
        transform.position = checkpointPos;
        anim.ResetTrigger("death");
        anim.Play("Idle-Animation");
        dead = false;
    }

    private void heartsUpdate()
    {
        float i = lives + 1;
        Image heart = GameObject.Find("Heart " + i).GetComponent<Image>();
        Image eHeart = GameObject.Find("eHeart " + i).GetComponent<Image>();

        heart.enabled = false;
        eHeart.enabled = true;
    }

    private void restartLevel()
    {
        lives = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
