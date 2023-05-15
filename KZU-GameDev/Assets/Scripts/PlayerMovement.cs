using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;



    private bool facingRight;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (DialogueManager.isActive == true)
        {
            speed = 0f;
        }
        else
        {
            speed = 1.5f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        
         if (movement.magnitude > 1f)
        {
            movement = movement.normalized;
        }
        
        rb.velocity = movement * speed;

        if (DialogueManager.isActive == true)
            animator.SetBool("isMoving", false);

        if (DialogueManager.isActive == true)
            return;
 

        if (horizontal > 0.1f && !facingRight)
        {
            Flip();
        }

        if (horizontal < -0.1f && facingRight)
        {
            Flip();
        }

        

        //Animations

        animator.SetFloat("InputHorizontal", horizontal);
        animator.SetFloat("InputVertical", vertical);
        
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
       
       
        if (horizontal == 0 && vertical < -0.1)
        {
            animator.SetBool("isWalkingDown", true);
        }
        else if(vertical > 0.1 || horizontal != 0)
        {
            animator.SetBool("isWalkingDown", false);
        }
        
        
        if (horizontal == 0 && vertical > 0.1)
        {
            animator.SetBool("isWalkingUp", true);
        }
        else if(vertical < -0.1 || horizontal != 0)
        {
            animator.SetBool("isWalkingUp", false);
        }




    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }  
    
    }
}
