using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private ER_GameManager gameManager;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = ER_GameManager.Instance;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            var playerMovement = collision.transform.GetComponent<FB_Player>();

            if (playerMovement != null)
            {
                gameManager.SelectWinner(playerMovement.player);
                Destroy(playerMovement.gameObject);
            }
        }
    }
}
