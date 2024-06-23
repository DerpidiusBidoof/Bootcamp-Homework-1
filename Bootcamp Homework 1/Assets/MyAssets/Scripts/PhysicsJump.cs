using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsJump : MonoBehaviour
{

    [SerializeField] float jumpForce = 10;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DoAJump();
    }

    private void DoAJump()
    {
        //If the space key is pressed Adds force onto the rigidbody to make it move upward.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
            print("jump pressed");
        }
    }
}
