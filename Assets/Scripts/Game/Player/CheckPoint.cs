using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //Access the script PlayerLife
    PlayerLife gameController;

    //Checkpoint sound effect
    [SerializeField] private AudioSource checkpointSFX;
    private void Awake()
    {
        //Find the player
        gameController = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerLife>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            //Input the position of the player into the function UpdateCheckpoint
            //Then player sound effect
            gameController.UpdateCheckpoint(transform.position);
            checkpointSFX.Play();
        }
    }
}
