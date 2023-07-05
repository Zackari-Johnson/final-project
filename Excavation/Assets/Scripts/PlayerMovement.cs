
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;

    public float moveSpeed = 40f;

    float horizontalInput = 0f;

    bool jump = false;
    bool cancelJump = false;

    void Update()
    {
        if (!PauseMenu.isPaused)
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
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalInput * Time.fixedDeltaTime, jump, cancelJump);
        jump = false;
        cancelJump = false;
    }
}
