using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;  

    // Another way of setting reference to a component if not public 
    void Start() {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Set v3 change (xyz) to 0. Get available input. Callall UpdateAnimationAndMove()
    void Update() 
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();

    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            //Must be exact same as Blend Tree Left Panel +
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void MoveCharacter() 
    {
        myRigidBody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
}
