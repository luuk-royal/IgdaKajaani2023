using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMove2 : MonoBehaviour
{
   
    public float moveSpeed = 5f; // Adjust the speed as needed

    public Rigidbody2D rb;

    public Weapon weapon;

    public GameObject Arrow_with_Fire;

    Vector2 moveDirection;
  

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // Input for movement using "W," "A," "S," and "D" keys
        float moveX = 0f;
        float moveY = 0f;


        // Check for "A" key
        if (Input.GetKey("a"))
            moveX = -1f;
        // Check for "D" key
        if (Input.GetKey("d"))
            moveX = 1f;

        // Calculate the movement vector
        Vector2 movement = new Vector2(moveX, moveY).normalized * moveSpeed;


        //shoot the arrow
        if (Input.GetKeyDown(KeyCode.Space))
        {
            weapon.Fire();
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

        private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    
}
