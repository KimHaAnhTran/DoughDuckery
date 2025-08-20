using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //Get the location of the destinations
    [SerializeField] private GameObject[] waypoints;

    //Index of a list of waypoints for the platform
    private int currentWaypointIndex = 0;

    private SpriteRenderer sprite;

    //Speed of how fast the platform will move
    [SerializeField] private float speed = 2f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true;
    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position,transform.position) < .1f)
        {
            //If the distance between the platform and its destination is less than 0.1f
            //Then the index moves to the position of the next destination
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) {
                //If the index is higher than the amount of waypoints
                //Then set index back to 0
                currentWaypointIndex = 0;
            }

            //Change direction of the platform whenever they move
            if (sprite.flipX)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }

        //The platform will start moving from its current position to the position of its next destination
        //1st argument is its current position
        //2nd argument is the position of the next waypoint
        //3rd argument is how fast the platform moves
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

        
    }
}
