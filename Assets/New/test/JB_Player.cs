using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ER_PlayerMovement;

public class JB_Player : MonoBehaviour
{
    public enum ControlScheme
    {
        WASD,
        ArrowKeys
    }
    [SerializeField] private float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float maxJumpTime = 0.5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb2d;
    private bool isGrounded;
    [SerializeField] private ControlScheme controlScheme = ControlScheme.WASD;
    private float jumpVel;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Player player;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        var jumpInput = Input.GetKeyDown(KeyCode.W);
        var jumpInputReleased = Input.GetKeyUp(KeyCode.W);

        if (player == Player.Player2)
        {
            jumpInput = Input.GetKeyDown(KeyCode.UpArrow);
            jumpInputReleased = Input.GetKeyUp(KeyCode.UpArrow);
        }

        float moveHorizontal = 0f;
        switch (controlScheme)
        {
            case ControlScheme.WASD:
                moveHorizontal = WASDControls();
                break;
            case ControlScheme.ArrowKeys:
                moveHorizontal = ArrowKeyControls();
                break;
        }

        rb2d.velocity = new Vector2(moveHorizontal * moveSpeed, rb2d.velocity.y);

        if (jumpInput && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            animator.SetBool("jump", true);
        }

        if (jumpInputReleased || rb2d.velocity.y <= 0)
        {
            animator.SetBool("jump", false);
        }

        if (jumpInputReleased && rb2d.velocity.y > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
        }
    }

    private float WASDControls()
    {
        float moveHorizontal = Input.GetKey(KeyCode.A) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0;
        animator.SetBool("isRunning", moveHorizontal != 0);
        spriteRenderer.flipX = moveHorizontal < 0;
        return moveHorizontal;
    }

    private float ArrowKeyControls()
    {
        float moveHorizontal = Input.GetKey(KeyCode.LeftArrow) ? -1 : Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
        animator.SetBool("isRunning", moveHorizontal != 0);
        spriteRenderer.flipX = moveHorizontal < 0;
        return moveHorizontal;
    }

}
