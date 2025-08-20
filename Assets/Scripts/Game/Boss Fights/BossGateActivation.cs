using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class BossGateActivation : MonoBehaviour
{
    //public CinemachineVirtualCamera vcam;
    public bool bossGateTrigger = false;
    public PlayableDirector cutsceneDirector;


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            bossGateTrigger = true;
            cutsceneDirector.Play();
        }
    }
}
