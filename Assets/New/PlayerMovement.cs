using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;

    [SerializeField] private float runSpeed = 2;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float sprintMultiplier = 1.5f;
    private bool isSprinting = false;

    void Start()
    {
        sprintSpeed = runSpeed;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Check for sprint input
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    void FixedUpdate()
    {
        if (isSprinting)
        {
            MovePlayer(horizontal, vertical, runSpeed * sprintMultiplier);
        }
        else
        {
            MovePlayer(horizontal, vertical, runSpeed);
        }
    }

    private void MovePlayer(float horiz, float vert, float speed)
    {
        if (horiz != 0 && vert != 0)
        {
            horiz *= moveLimiter;
            vert *= moveLimiter;
        }

        rb.velocity = new Vector2(horiz * speed, vert * speed);
    }
}
