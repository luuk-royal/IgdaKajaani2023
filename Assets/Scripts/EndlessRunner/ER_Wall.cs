using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_Wall : MonoBehaviour
{
    [SerializeField] private ER_GameManager gameManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerMovement = collision.GetComponent<ER_PlayerMovement>();

            if (playerMovement != null) 
            { gameManager.SelectWinner(playerMovement.player); }
        }
    }
}
