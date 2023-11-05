using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpVelocity = 10f;

    public KeyCode jumpKey;

    public float tiltSmooth = 5f;
    private Quaternion downRotation;
    private Quaternion forwardRotation;

    private void Start()
    {
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
    }

    void Update()
    {

        HandleJumping();

        if (rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, forwardRotation, tiltSmooth * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pipe")
        {
            
        }
    }

    public void TiltUpwards()
    {
        transform.rotation = forwardRotation;
    }

    void HandleJumping()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            rb.gravityScale = 0.6f;
            rb.velocity = Vector2.up * jumpVelocity;
            TiltUpwards();
        }
    }

}
