using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerBurnCalories : MonoBehaviour
{
    [SerializeField]
    private KeyCode downKey = KeyCode.None;

    [SerializeField]
    private Sprite squattingSprite = null;
    private Sprite originalSprite = null;

    private SpriteRenderer mySpriteRenderer = null;
    private Animator myAnimator = null;

    private int myScore = 0;

    [SerializeField]
    private TextMeshProUGUI myScoreText = null;

    public Player player;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myAnimator.enabled = false;

        originalSprite = mySpriteRenderer.sprite;
    }

    private void Update()
    {
        if (BurnCaloriesManager.Instance.IsGameRunning())
        {
            if (Input.GetKeyDown(downKey))
            {
                mySpriteRenderer.sprite = squattingSprite;
                IncrementPoints();

                transform.Rotate(0, 180, 0);
            }

            if (Input.GetKeyUp(downKey))
            {
                mySpriteRenderer.sprite = originalSprite;
            }
        }
    }

    private void IncrementPoints()
    {
        myScore++;
        myScoreText.text = myScore.ToString();
    }

    public int GetScore()
    {
        return myScore;
    }

    public void Kill()
    {
        myAnimator.enabled = true;
        myAnimator.SetTrigger("Kill");
    }
}
