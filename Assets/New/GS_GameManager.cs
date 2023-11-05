using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GS_GameManager : MonoBehaviour
{
    public List<Sprite> randomSprites;
    public Sprite fireSprite;

    public List<Image> slots;
    public List<TextMeshProUGUI> slotTexts;

    private Image correctSlot;

    public bool canGuess;
    public ER_GameManager gameManager;

    private void Start()
    {
        StartCoroutine(ChooseNextSlot());
    }

    public IEnumerator ChooseNextSlot()
    {
        var randNum = Random.Range(0, 4);
        correctSlot = slots[randNum];

        yield return new WaitForSeconds(Random.Range(3, 10));

        correctSlot.sprite = fireSprite;

        canGuess = true;

        for (int i = 0; i < 4; i++)
        {
            slots[i].enabled = true;
            slotTexts[i].enabled = false;

            if (slots[i] != correctSlot)
            slots[i].sprite = randomSprites[Random.Range(0, randomSprites.Count)];
        }


    }

    public void Guess(Player player, int guessID)
    {
        if (!canGuess) return;

        canGuess = false;

        switch (guessID)
        {
            case 1:
                if(correctSlot == slots[0])
                {
                    if(player == Player.Player1)
                    gameManager.SelectWinner(Player.Player1);
                    else
                    {
                        gameManager.SelectWinner(Player.Player2);
                    }
                }
                else
                {
                    if (player == Player.Player1)
                        gameManager.SelectWinner(Player.Player2);
                    else
                    {
                        gameManager.SelectWinner(Player.Player1);
                    }
                }
                break;
            case 2:
                if (correctSlot == slots[2])
                {
                    if (player == Player.Player1)
                        gameManager.SelectWinner(Player.Player1);
                    else
                    {
                        gameManager.SelectWinner(Player.Player2);
                    }
                }
                else
                {
                    if (player == Player.Player1)
                        gameManager.SelectWinner(Player.Player2);
                    else
                    {
                        gameManager.SelectWinner(Player.Player1);
                    }
                }
                break;
            case 3:
                if (correctSlot == slots[1])
                {
                    if (player == Player.Player1)
                        gameManager.SelectWinner(Player.Player1);
                    else
                    {
                        gameManager.SelectWinner(Player.Player2);
                    }
                }
                else
                {
                    if (player == Player.Player1)
                        gameManager.SelectWinner(Player.Player2);
                    else
                    {
                        gameManager.SelectWinner(Player.Player1);
                    }
                }
                break;
            case 4:
                if (correctSlot == slots[3])
                {
                    if (player == Player.Player1)
                        gameManager.SelectWinner(Player.Player1);
                    else
                    {
                        gameManager.SelectWinner(Player.Player2);
                    }
                }
                else
                {
                    if (player == Player.Player1)
                        gameManager.SelectWinner(Player.Player2);
                    else
                    {
                        gameManager.SelectWinner(Player.Player1);
                    }
                }
                break;
        }
    }
}
