using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FB_Fire : MonoBehaviour
{
    [SerializeField] private ER_GameManager gameManager;

    public float raycastDistance = 10f;
    public LayerMask playerLayer;

    void Update()
    {
        Vector2 rayOrigin = transform.position;
        Vector2 rayDirection = transform.up;

        Debug.DrawRay(rayOrigin, rayDirection * raycastDistance, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, raycastDistance, playerLayer);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                gameManager.SelectWinner(hit.transform.GetComponent<FB_Player>().player);
            }
        }
    }
}
