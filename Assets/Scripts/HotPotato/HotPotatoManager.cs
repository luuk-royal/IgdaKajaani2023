using UnityEngine;
using TMPro;

public class HotPotatoManager : MonoBehaviour
{

    public TextMeshProUGUI playerOneText;
    public TextMeshProUGUI playerTwoText;
    public TextMeshProUGUI timeLeftText;

    public Animator animatorOne;
    public Animator animatorTwo;

    private Player holdingPlayer;

    private Vector3 positionOne = new Vector3(-5f, 0, 0);
    private Vector3 positionTwo = new Vector3(4.5f, 0, 0);

    private float scoreTimePlayerOne;
    private float scoreTimePlayerTwo;
    private float timeHeld;
    private float timer;
    private float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        scoreTimePlayerOne = 0;
        scoreTimePlayerTwo = 0;

        playerOneText.text = $"{scoreTimePlayerOne} S";
        playerTwoText.text = $"{scoreTimePlayerTwo} S";

        timeHeld = 0;
        totalTime = 30;

        timeLeftText.text = $"{totalTime} S";

        holdingPlayer = Player.Player1;
        transform.position = positionOne;
        timer = Random.Range(5.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeftText.text = $"{totalTime.ToString("F2")} S";

        timeHeld += Time.deltaTime;
        if (timeHeld >= timer)
        {
            if (holdingPlayer == Player.Player1)
            {
                animatorOne.SetTrigger("Death");
                new WaitForSeconds(2.0f);
                ER_GameManager.Instance.SelectWinner(Player.Player1);
                Destroy(this);
            }
            else
            {
                animatorTwo.SetTrigger("Death");
                ER_GameManager.Instance.SelectWinner(Player.Player2);
                Destroy(this);
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

        totalTime -= Time.deltaTime;
        if (totalTime < 0)
        {
            timeOut();
        }
    }

    public void timeOut()
    {
        if (holdingPlayer == Player.Player1)
        {
            if (timeHeld > scoreTimePlayerOne)
            {
                scoreTimePlayerOne = timeHeld;
                playerOneText.text = $"{scoreTimePlayerOne.ToString("F2")} S";
            }
        }
        else
        {
            if (timeHeld > scoreTimePlayerTwo)
            {
                scoreTimePlayerTwo = timeHeld;
                playerTwoText.text = $"{scoreTimePlayerTwo.ToString("F2")} S";
            }
        }

        if (scoreTimePlayerOne > scoreTimePlayerTwo)
        {
            animatorOne.SetTrigger("Death");
            // animator.();
            ER_GameManager.Instance.SelectWinner(Player.Player2);
            Destroy(this);
        } else
        {
            animatorTwo.SetTrigger("Death");
            ER_GameManager.Instance.SelectWinner(Player.Player1);
            Destroy(this);
        }
    }

    public void ThrowPotato(Player player)
    {
        if (holdingPlayer == player)
        {
            if (player == Player.Player2) { 
                transform.position = positionOne;
                holdingPlayer = Player.Player1;

                if (timeHeld > scoreTimePlayerTwo)
                {
                    scoreTimePlayerTwo = timeHeld;
                    playerTwoText.text = $"{scoreTimePlayerTwo.ToString("F2")} S";
                }
            } else
            {
                transform.position = positionTwo;
                holdingPlayer = Player.Player2;

                if (timeHeld > scoreTimePlayerOne)
                {
                    scoreTimePlayerOne = timeHeld;
                    playerOneText.text = $"{scoreTimePlayerOne.ToString("F2")} S";
                }
            }

            timeHeld = 0;
        }
    }
}
