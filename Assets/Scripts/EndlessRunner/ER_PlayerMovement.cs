using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class ER_PlayerMovement : MonoBehaviour
{
    public enum ControlScheme
    {
        WASD,
        ArrowKeys
    }

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private ControlScheme controlScheme = ControlScheme.WASD;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;

    public Player player;

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        switch (controlScheme)
        {
            case ControlScheme.WASD:
                WASDControls();
                break;
            case ControlScheme.ArrowKeys:
                ArrowKeyControls();
                break;
        }
    }

    private void WASDControls()
    {
        float moveHorizontal = Input.GetKey(KeyCode.A) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0;

        animator.SetBool("isRunning", moveHorizontal != 0);
        spriteRenderer.flipX = moveHorizontal == 1 ? false : true ;

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        MovePlayer(moveHorizontal);
    }

    private void ArrowKeyControls()
    {
        float moveHorizontal = Input.GetKey(KeyCode.LeftArrow) ? -1 : Input.GetKey(KeyCode.RightArrow) ? 1 : 0;

        animator.SetBool("isRunning", moveHorizontal != 0);
        spriteRenderer.flipX = moveHorizontal == 1 ? false : true;

        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        MovePlayer(moveHorizontal);
    }

    private void MovePlayer(float moveHorizontal)
    {
        Vector2 targetVelocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
        rb.velocity = targetVelocity;
    }

}