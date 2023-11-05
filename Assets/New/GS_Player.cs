using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_Player : MonoBehaviour
{
    public Player player;
    public GS_GameManager gameManager;

    private bool inputReceived = false;

    void Update()
    {
        if (!gameManager.canGuess) return;
        if (inputReceived) return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            gameManager.Guess(player, 2);
            inputReceived = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            gameManager.Guess(player, 1);
            inputReceived = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            gameManager.Guess(player, 4);
            inputReceived = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            gameManager.Guess(player, 3);
            inputReceived = true;
        }
    }

    public void ResetInput()
    {
        inputReceived = false;
    }
}
