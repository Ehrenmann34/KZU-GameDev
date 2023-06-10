using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour

{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 5f;

    int waypointIndex = 0;
    private Vector2 previousPosition;

    void Start() {
        transform.position = waypoints [waypointIndex].transform.position;
    }

    void Update() {
        pointsmove ();
    }

    void pointsmove()
    {
        transform.position = Vector2.MoveTowards (transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints [waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    private void FlipCatBasedOnMovement()
    {
        Vector2 currentDirection = (Vector2)transform.position - previousPosition;

        if (currentDirection.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (currentDirection.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        previousPosition = transform.position;
    }
}


