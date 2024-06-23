using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpCode : MonoBehaviour
{
    [SerializeField] float jumpHeight = 5;
    [SerializeField] float gravityScale = 5;

    float velocity;

    [SerializeField] float floorHeight = 0.5f;
    [SerializeField] Transform feet;
    [SerializeField] ContactFilter2D filter; // allows you to ignore or include particular colliders from being detected.
    
    bool isGrounded;

    Collider2D[] results = new Collider2D[1]; //records a refernece to any colliders that are found in a local array.


    void Start()
    {
        
    }


    void Update()
    {
       MakeObjectJump();
    }
    private void MakeObjectJump()
    {
        //adds gravity to objects velocity. Does not move object, will change intended trajectory of object.
        velocity += Physics2D.gravity.y * gravityScale * Time.deltaTime; 

        //will prevent the object from falling through the world (turns of gravity if object is on the ground). Also checks if object is grounded and if is, resets velocity to 0.
        if (Physics2D.OverlapBox(feet.position, feet.localScale, 0 , filter, results) > 0 && velocity < 0) 
        {
            velocity = 0;

            //snaps object to correct position should it start to clip through the ground.
            Vector2 surface = Physics2D.ClosestPoint(transform.position, results[0]) + Vector2.up *floorHeight;
            transform.position = new Vector3(transform.position.x, surface.y, transform.position.z);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //if player does jump, apply any new jumping velocity after gravity and ground checks so new jump is not canceled out because object is grounded. 
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            //velocity = jumpHeight;
            velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * gravityScale));
        }

        //this one actually moves the object. 
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }
}
