using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{


    [SerializeField] Text timeDisplay, scoreDisplay;
    [SerializeField] float gameDuration;
    [SerializeField] GameObject gameOverScreen;
    bool playing = true;
    Text gameOverText;
    public float time;
    public int bluePoints, redPoints;


    void Start()
    {
        time = gameDuration;
        timeDisplay.text = "<b>" + Mathf.RoundToInt(time).ToString() + "</b>";
        scoreDisplay.text = "<b>0-0</b>";
        gameOverText = gameOverScreen.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
    }

    void Update()
    {
        if (time > 0 && playing)
        {
            time -= Time.deltaTime;
            timeDisplay.text = "<b>" + Mathf.RoundToInt(time).ToString() + "</b>";
        }
        else if (time <= 0 && playing)
        {
            gameOver();
        }
    }

    public void updateScore()
    {
        scoreDisplay.text = "<b>" + redPoints.ToString() + "-" + bluePoints.ToString() + "</b>";
    }

    public void gameOver()
    {
        if (bluePoints > redPoints)
        {
            gameOverText.color = Color.blue;
            gameOverText.text = "<b>BLUE WINS!</b>";
        }
        else if (bluePoints < redPoints)
        {
            gameOverText.color = Color.red;
            gameOverText.text = "<b>RED WINS!</b>";
        }
        else if (bluePoints == redPoints)
        {
            gameOverText.color = Color.yellow;
            gameOverText.text = "<b>DRAW!</b>";
        }
        gameOverScreen.SetActive(true);
        gameOverText.transform.localScale = Vector3.Lerp(gameOverText.transform.localScale, new Vector3(1,1,1), 0.1f);
        if (gameOverText.transform.localScale == new Vector3(1,1,1))
            playing = false;
    }
}
