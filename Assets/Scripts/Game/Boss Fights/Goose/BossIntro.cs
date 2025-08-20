using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntro : MonoBehaviour
{
    [SerializeField] public AudioSource bossRoar;

    public void roar()
    {
        bossRoar.Play();
    }
}
