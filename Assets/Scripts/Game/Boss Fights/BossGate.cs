using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGate : MonoBehaviour
{
    public BossGateActivation gateActive;
    [SerializeField] GameObject waypoint;
    [SerializeField] private float speed = 2f;
    // Update is called once per frame
    void Update()
    {
        if (gateActive.bossGateTrigger)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, Time.deltaTime * speed);
        }
    }
}
