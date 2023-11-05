using UnityEngine;

public class Potato : MonoBehaviour
{
    [SerializeField] private ER_GameManager gameManager;

    private Player holdingPlayer;

    private Vector3 positionOne = new Vector3(-5f, 0, 0);
    private Vector3 positionTwo = new Vector3(4.5f, 0, 0);

    private float timeHeld = 0;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        holdingPlayer = Player.Player1;
        transform.position = positionOne;
        timer = Random.Range(5.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeHeld += Time.deltaTime;
        if (timeHeld >= timer)
        {
            if (holdingPlayer == Player.Player1)
            {
                gameManager.SelectWinner(Player.Player2);
            }
            else
            {
                gameManager.SelectWinner(Player.Player1);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ThrowPotato(Player.Player1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ThrowPotato(Player.Player2);
        }
    }

    public void ThrowPotato(Player player)
    {
        if (holdingPlayer == player)
        {
            if (player == Player.Player2) { 
                transform.position = positionOne;
                holdingPlayer = Player.Player1;
            } else
            {
                transform.position = positionTwo;
                holdingPlayer = Player.Player2;
            }
        }
    }
}
