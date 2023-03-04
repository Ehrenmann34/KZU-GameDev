using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
    
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        
         if (movement.magnitude > 1f)
        {
            movement = movement.normalized;
        }

        rb.velocity = movement * speed;
    }
}
