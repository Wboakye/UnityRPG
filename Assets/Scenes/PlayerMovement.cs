using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;  

    // Another way of setting reference to a component if not public. 
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Set v3 change (xyz) to 0. Get available input. If input, call MoveCharacter()
    void Update() {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(change != Vector3.zero)
        {
            MoveCharacter();
        }

    }

    void MoveCharacter() {
        myRigidBody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
}
