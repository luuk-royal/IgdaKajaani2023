using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int p1Score, p2Score;
    [SerializeField] private TextMeshProUGUI p1ScoreTxt, p2ScoreTxt;

    private void Start()
    {
        UpdatePlayerScores();
    }
    public void GainScore(Player player, int score)
    {
        if(player == Player.Player1)
        {
            p1Score += score;
        }        
        else if(player == Player.Player2)
        {
            p2Score += score;
        }

        UpdatePlayerScores();
    }

    private void UpdatePlayerScores()
    {
        p1ScoreTxt.text = $"P1: {p1Score}";
        p2ScoreTxt.text = $"P2: {p2Score}";
    }
}
