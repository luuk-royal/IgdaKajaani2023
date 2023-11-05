using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ER_Wall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerMovement = collision.GetComponent<ER_PlayerMovement>();

            if (playerMovement != null)
            {
                ER_GameManager.Instance.SelectWinner(playerMovement.player);
                Destroy(playerMovement.gameObject);
            }
        }
    }
}