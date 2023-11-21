using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Player
{
    Player1,
    Player2
}

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private List<MiniGameData> allMiniGames;

    private Queue<MiniGameData> playedMiniGames = new Queue<MiniGameData>();
    private int avoidRepeatingLastN = 3;
    private MiniGameData currentMiniGame;

    public static MinigameManager Instance { get; private set; }
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)){
            SelectWinner(Player.Player1);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            SelectWinner(Player.Player2);
        }
    }

    private void Start()
    {
        SelectAndLoadMiniGame();
    }

    public void SelectAndLoadMiniGame()
    {
        List<MiniGameData> availableMiniGames = allMiniGames.Except(playedMiniGames).ToList();

        if (availableMiniGames.Count == 0)
        {
            availableMiniGames = allMiniGames.ToList();
        }

        currentMiniGame = availableMiniGames[Random.Range(0, availableMiniGames.Count)];

        SceneManager.LoadScene(currentMiniGame.sceneName);

        playedMiniGames.Enqueue(currentMiniGame);

        if (playedMiniGames.Count > avoidRepeatingLastN)
        {
            playedMiniGames.Dequeue();
        }
    }

    public void SelectWinner(Player player)
    {
        scoreManager.GainScore(player, currentMiniGame.score);

        SelectAndLoadMiniGame();
    }
}
