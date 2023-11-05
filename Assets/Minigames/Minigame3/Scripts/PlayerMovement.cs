using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float dampening = 0.95f; // Increase the dampening factor (0.0f - 1.0f) for more slipperiness

    private Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    Vector2 moveDirection;

    public int health = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Input for movement using arrow keys
        float moveX = 0f;
        float moveY = 0f;

        // Check for arrow keys
        if (Input.GetKey(KeyCode.UpArrow))
            moveY = 1f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
            moveX = 1f;
        }

        // Calculate the movement vector
        Vector2 movement = new Vector2(moveX, moveY).normalized * moveSpeed;

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        // Apply dampening to reduce speed gradually
        rb.velocity *= dampening;
    }

    public void TakeHit()
    {
        health--;

        if(health <= 0)
        {
            Destroy(gameObject);
            ER_GameManager.Instance.SelectWinner(Player.Player1);
        }
    }
}
