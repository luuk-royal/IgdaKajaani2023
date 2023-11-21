using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ER_Wall : MonoBehaviour
{
    [SerializeField] private ER_GameManager gameManager;


    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = ER_GameManager.Instance;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerMovement = collision.GetComponent<JB_Player>();

            if (playerMovement != null)
            {
                ER_GameManager.Instance.SelectWinner(playerMovement.player);
                playerMovement.animator.SetTrigger("death");
                Destroy(playerMovement);
            }
        }
    }

}