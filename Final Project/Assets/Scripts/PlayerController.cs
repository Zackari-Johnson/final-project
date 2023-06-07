using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityStrength;

    public int jumpCount;
    int jumpsLeft = 1;

    private bool isGrounded;

    public float moveInput;

    public Rigidbody2D playerRb;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

    }

   
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Jump();
        Move();
        ApplyGravity();
    }



    public void Move()
    {
        playerRb.velocity = new Vector2(moveInput * moveSpeed, playerRb.velocity.y);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);

        }
    }

    public void ApplyGravity()
    {
        playerRb.velocity -=  new Vector2(playerRb.velocity.x, playerRb.velocity.y + gravityStrength * Time.deltaTime);
        
    }
    
}
