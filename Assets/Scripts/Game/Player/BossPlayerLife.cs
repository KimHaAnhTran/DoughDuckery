using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossPlayerLife : MonoBehaviour
{
    private Animator anim;
    private bool dead = false;
    public float lives = 5f;
    FadeInOut fade;

    [SerializeField] private AudioSource deathSFX;
    Vector2 checkpointPos;
    private void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
        anim = GetComponent<Animator>();
        checkpointPos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && !dead)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!dead)
        {
            dead = true;
            anim.SetTrigger("death");
            deathSFX.Play();

        }
        
        
    }

    private void Respawn()
    {
        lives--;
        if (lives > 0)
        {
            heartsUpdate();
            transform.position = checkpointPos;
            anim.ResetTrigger("death");
            anim.Play("Idle-Animation");
            dead = false;
        }
        else
        {
            fade.FadeIn();
            StartCoroutine(_ChangeScene());
            
        }
        
    }

    public IEnumerator _ChangeScene()
    {
        yield return new WaitForSeconds(1f);
        LoseSwitch();
    }

    private void LoseSwitch()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    private void heartsUpdate()
    {
        float i = lives + 1;
        Image heart = GameObject.Find("Heart " + i).GetComponent<Image>();
        Image eHeart = GameObject.Find("eHeart " + i).GetComponent<Image>();

        heart.enabled = false;
        eHeart.enabled = true;
    }




}
