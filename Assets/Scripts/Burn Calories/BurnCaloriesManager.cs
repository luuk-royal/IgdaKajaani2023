using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BurnCaloriesManager : MonoBehaviour
{
    private bool gameIsFinished = false;

    [SerializeField]
    private int timeForGameToFinish = 10;

    [SerializeField]
    private TextMeshProUGUI timerText = null;

    private float counter = 0f;

    [SerializeField]
    private PlayerControllerBurnCalories purplePlayer = null;

    [SerializeField]
    private PlayerControllerBurnCalories orangePlayer = null;

    public static BurnCaloriesManager Instance { private set; get; } = null;

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

    private void Start()
    {
        StartCoroutine(TimerCoroutine());

        timerText.text = timeForGameToFinish.ToString();
    }

    private IEnumerator TimerCoroutine()
    {
        float intervalInSeconds = 0.2f;
        WaitForSeconds timeToWait = new WaitForSeconds(intervalInSeconds); //Updates every 0.2 seconds roughty

        while (!gameIsFinished)
        {
            yield return timeToWait;
            counter += intervalInSeconds;

            int differenceInTime = (int)Mathf.Ceil(timeForGameToFinish - counter);
            timerText.text = differenceInTime.ToString();

            if (counter > timeForGameToFinish)
            {
                gameIsFinished = true;
            }
        }

        FinishGame();
    }

    private void FinishGame()
    {
        var winningPlayer = Player.Player1;

        if (orangePlayer.GetScore() > purplePlayer.GetScore())
        {
            purplePlayer.Kill();
            winningPlayer = Player.Player2;
        }
        else
        {
            if (orangePlayer.GetScore() < purplePlayer.GetScore())
            {
                orangePlayer.Kill();
                winningPlayer = Player.Player1;
            }
            else
            {
                purplePlayer.Kill();
                orangePlayer.Kill();
            }
        }

        ER_GameManager.Instance.SelectWinner(winningPlayer);
    }

    public bool IsGameRunning()
    {
        return !gameIsFinished;
    }
}
