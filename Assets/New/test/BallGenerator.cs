using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject ballPrefab;
    public float minSpawnInterval = 1f; // Minimum spawn interval
    public float maxSpawnInterval = 5f; // Maximum spawn interval
    public float minBallSpeed = 2f; // Minimum ball speed
    public float maxBallSpeed = 10f; // Maximum ball speed
    public float despawnDistance = 10f; // Distance at which balls will despawn

    private float nextSpawnTime;

    void Start()
    {
        ScheduleNextSpawn();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnBall();
            ScheduleNextSpawn();
        }
    }

    void SpawnBall()
    {
        bool spawnFromLeft = Random.Range(0, 2) == 0;

        Vector3 spawnPosition = new Vector3(spawnFromLeft ? -despawnDistance : despawnDistance, transform.position.y, transform.position.z);
        GameObject ball = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);

        // Assign random speed within the range
        float ballSpeed = Random.Range(minBallSpeed, maxBallSpeed);

        BallMover ballMover = ball.AddComponent<BallMover>();
        Vector2 moveDirection = spawnFromLeft ? Vector2.right : Vector2.left;

        // If the ball is moving to the right, apply a negative rotation to spin it counter-clockwise
        if (moveDirection == Vector2.right)
        {
            ballMover.transform.GetChild(0).transform.GetComponent<ConstantRotation>().rotationSpeed = -250f;
        }

        ballMover.Setup(moveDirection, ballSpeed, despawnDistance * 2);
    }

    void ScheduleNextSpawn()
    {
        // Assign random interval for the next spawn
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}