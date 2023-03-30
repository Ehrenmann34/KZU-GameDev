using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private bool facingRight;

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

        if (horizontal > 0.1f && !facingRight)
        {
            Flip();
        }

        if (horizontal < -0.1f && facingRight)
        {
            Flip();
        }


        //Animations

        //Walking sideways
        if (horizontal != 0f)
        {
            animator.SetBool("walking sideways", true);
        }
        else
        {
            animator.SetBool("walking sideways", false);
        }

        //Walking up and down
        if (vertical < -0.1f)
        {
            animator.SetBool("walking front", true);
        }
        else if (vertical > 0.1f)
        {
            animator.SetBool("walking back", true);
        }
        else
        {
            animator.SetBool("walking front", false);
            animator.SetBool("walking back", false);
        }

        if (animator.GetBool("walking sideways") == true)
        {
            animator.SetBool("walking front", false);
            animator.SetBool("walking back", false);
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }  
}
