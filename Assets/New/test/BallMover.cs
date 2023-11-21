using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    private Vector2 moveDirection;
    private float ballSpeed;
    private float despawnDistance;
    private float moveDistance;

    public void Setup(Vector2 direction, float speed, float despawnDist)
    {
        moveDirection = direction;
        ballSpeed = speed;
        despawnDistance = despawnDist;
        moveDistance = 0f;
    }

    void Update()
    {
        
        float moveStep = ballSpeed * Time.deltaTime;
        transform.Translate(moveDirection * moveStep);
        moveDistance += moveStep;


        if (moveDistance >= despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}