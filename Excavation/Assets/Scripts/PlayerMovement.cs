
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;

    public float moveSpeed = 40f;

    float horizontalInput = 0f;

    bool jump = false;
    bool cancelJump = false;

    public float coyoteTime = 0.2f;
    private float coyoteTimer;
    public float bufferTime = 0.3f;
    private float bufferTimer;

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
            cancelJump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalInput * Time.fixedDeltaTime, jump, cancelJump);
        jump = false;
        cancelJump = false;
    }
}
