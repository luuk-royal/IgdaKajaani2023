using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ER_MovingObject : MonoBehaviour
{
    private float speed = 5f;
    private float resetPositionX = -30f;
    [SerializeField] private float startPositionX = 10f;

    [SerializeField] private List<GameObject> randomBlocks;
    private GameObject currentBlockFront, currentBlockBack;

    [SerializeField] private Transform frontHolder, backHolder;

    private bool frontIsFront = true;

    private void Start()
    {
        transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        currentBlockFront = Instantiate(GetRandomBlock(), frontHolder);
        currentBlockBack = Instantiate(GetRandomBlock(), backHolder);
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < resetPositionX)
        {
            resetPositionX -= 20f;

            if(frontIsFront)
            {
                Destroy(currentBlockFront);
                frontHolder.position = new Vector3(frontHolder.position.x + 40, frontHolder.position.y, frontHolder.position.z);
                currentBlockFront = Instantiate(GetRandomBlock(), frontHolder);
            }
            else
            {
                Destroy(currentBlockBack);
                backHolder.position = new Vector3(backHolder.position.x + 40, backHolder.position.y, backHolder.position.z);
                currentBlockBack = Instantiate(GetRandomBlock(), backHolder);
            }

            frontIsFront = !frontIsFront;
        }

        speed += 0.1f * Time.deltaTime;
    }

    private GameObject GetRandomBlock()
    {
        return randomBlocks[Random.Range(0, randomBlocks.Count)];
    }
}
