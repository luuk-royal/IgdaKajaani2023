using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ER_GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerWinPanel;
    [SerializeField] private TextMeshProUGUI playerWinText;

    private Player winnerPlayer;
    public bool gameOver;

    public static ER_GameManager Instance { private set; get; } = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Continue()
    {
        MinigameManager.Instance.SelectWinner(winnerPlayer);
    }

    public void SelectWinner(Player winner)
    {
        if (gameOver) return;

        gameOver = true;
        winnerPlayer = winner;
        playerWinText.text = $"Winner is {winnerPlayer}";

        playerWinPanel.SetActive(true);
    }
}
