using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public Transform[] waypoints;   // Array of waypoints defining the route
    public float movementSpeed = 2f; // Speed at which the cat moves
    private int currentWaypoint = 0; // Index of the current waypoint

    private void Update()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        if (waypoints.Length == 0) return;

        // Calculate the direction towards the current waypoint
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;
        direction.Normalize();

        // Move the cat towards the waypoint
        transform.Translate(direction * movementSpeed * Time.deltaTime);

        // If the cat has reached the current waypoint, move to the next one
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }
}


