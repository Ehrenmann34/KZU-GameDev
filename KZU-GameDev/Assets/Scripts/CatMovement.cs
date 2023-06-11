using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 5f;
    private int waypointIndex = 0;
    private Vector2 previousPosition;

    private void Start()
    {
        transform.position = waypoints[waypointIndex].position;
        previousPosition = transform.position;
    }

    private void Update()
    {
        MoveToNextWaypoint();
        FlipCatBasedOnMovement();
    }

    private void MoveToNextWaypoint()
    {
        Vector2 targetPosition = waypoints[waypointIndex].position;
        Vector2 currentPosition = transform.position;

        Vector2 direction = (targetPosition - currentPosition).normalized;
        Vector2 newPosition = currentPosition + direction * moveSpeed * Time.deltaTime;

        transform.position = newPosition;

        if (Vector2.Distance(currentPosition, targetPosition) < 0.1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }

    private void FlipCatBasedOnMovement()
    {
        Vector2 currentDirection = (Vector2)transform.position - previousPosition;

        if (currentDirection.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (currentDirection.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        previousPosition = transform.position;
    }
}



