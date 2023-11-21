using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_Player1 : MonoBehaviour
{
    public Player player;
    public GS_GameManager gameManager;

    private bool inputReceived = false;

    void Update()
    {
        if (inputReceived) return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameManager.Guess(player, 2);
            inputReceived = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameManager.Guess(player, 1);
            inputReceived = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameManager.Guess(player, 4);
            inputReceived = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
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
