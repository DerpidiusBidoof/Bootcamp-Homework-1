using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsJump : MonoBehaviour
{

    [SerializeField] float jumpHeight = 3;

    [SerializeField] float gravityScale = 5;
    [SerializeField] float fallGravityScale = 15;

    Rigidbody2D rb;

    float buttonPressedTime;
    public float buttonPressWindow;
    //public float cancelRate;
    bool isJumping;
    //bool jumpCanelled;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DoAJump();
        //HowToFall();
    }

    private void DoAJump()
    {
        float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;

        //If the space key is pressed Adds force onto the rigidbody to make it move upward.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale = gravityScale;
            //float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
            //rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            isJumping = true;
            buttonPressedTime = 0;
            //jumpCanelled = false;
        }

        if (isJumping)
        {
            buttonPressedTime += Time.deltaTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (buttonPressedTime > buttonPressWindow ||  Input.GetKeyUp(KeyCode.Space))
            {
                //rb.gravityScale = fallGravityScale;
                isJumping = false;
                //jumpCanelled = true;
            }

            if (rb.velocity.y < 0)
            {
                rb.gravityScale = fallGravityScale;
                isJumping = false;
            }
        }
    }

    /*private void FixedUpdate()
    {
        if (jumpCanelled && isJumping && rb.velocity.x > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }
    }*?

    /*void HowToFall()
    {
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = gravityScale;
        }
        else
        {
            rb.gravityScale = fallGravityScale;
        }
    }*/
}
