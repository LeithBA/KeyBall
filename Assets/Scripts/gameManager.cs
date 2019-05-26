using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{


    [SerializeField] Text timeDisplay, scoreDisplay;
    [SerializeField] float gameDuration;
    public float time;
    public int bluePoints, redPoints;

    void Start()
    {
        time = gameDuration;
        timeDisplay.text = "<b>" + Mathf.RoundToInt(time).ToString() + "</b>";
        scoreDisplay.text = "<b>0-0</b>";
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeDisplay.text = "<b>" + Mathf.RoundToInt(time).ToString() + "</b>";
        }
    }

    public void updateScore()
    {
        scoreDisplay.text = "<b>" + redPoints.ToString() + "-" + bluePoints.ToString() + "</b>";
    }

	public void gameOver()
	{
		
	}
}
