using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class ER_GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerWinPanel;
    [SerializeField] private TextMeshProUGUI playerWinText;

    private Player winnerPlayer;
    public bool gameOver;

    public UnityEvent onGameOver;

    public static ER_GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
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
        onGameOver?.Invoke();
        playerWinPanel.SetActive(true);
    }
}
