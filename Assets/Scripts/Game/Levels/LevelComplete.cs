using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public ItemCollector itemCollector;
    private bool isGateMove = false;
    [SerializeField] GameObject waypoint;
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (isGateMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player") && itemCollector.breads >= itemCollector.goal)
        {
            isGateMove = true;
        }
    }
}
