using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateMove : MonoBehaviour
{
    public KeyCollect keyCollect;
    public bool isGateMove = false;
    [SerializeField] GameObject waypoint;
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (isGateMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, Time.deltaTime * speed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (keyCollect.isCollect && collision.gameObject.CompareTag("player"))
        {
            Debug.Log("Touching Gate");
            isGateMove = true;
            
        }
    }
}
