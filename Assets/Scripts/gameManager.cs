using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{


    [SerializeField] Text timeDisplay, scoreDisplay;
    [SerializeField] float gameDuration;
    [SerializeField] public GameObject gameOverScreen;
    public bool playing = false, started = false;
    public Text gameOverText, gameOverSub;
    public float time;
    public int bluePoints, redPoints;
    public GameObject red, blue;
    public Transform redStart, blueStart;
    public playerController redPC, bluePC;
    PostProcessVolume PPV;
    ChromaticAberration chrom;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        time = gameDuration;

        redStart = red.transform;
        blueStart = blue.transform;

        PPV = Camera.main.GetComponent<PostProcessVolume>();
        PPV.profile.TryGetSettings(out chrom);

        gameOverText = gameOverScreen.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
    }

    void Update()
    {
        if (started && time > 0 && playing)
        {
            time -= Time.deltaTime;
            timeDisplay.text = "<b>" + Mathf.RoundToInt(time) + "</b>";
        }

        else if (started && !playing)
        {
            gameOverText.transform.localScale = Vector3.Lerp(gameOverText.transform.localScale, new Vector3(1, 1, 1), 0.1f);
            gameOverSub.transform.localScale = Vector3.Lerp(gameOverSub.transform.localScale, new Vector3(1, 1, 1), 0.1f);
            chrom.intensity.value = Mathf.Lerp(chrom.intensity.value, 1.0f, 0.1f);

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.L))
            {
                SceneManager.LoadScene(1);
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void updateScore()
    {
        scoreDisplay.text = "<b>" + redPoints + "-" + bluePoints + "</b>";
    }

    public void gameOver()
    {
        playing = false;
        gameOverScreen.SetActive(true);
        bluePC.enabled = false;
        redPC.enabled = false;

        if (bluePoints > redPoints)
        {
            gameOverText.color = Color.blue;
            gameOverSub.color = Color.blue;
            gameOverText.text = "<b>BLUE WINS!</b>";
        }
        else if (bluePoints < redPoints)
        {
            gameOverText.color = Color.red;
            gameOverSub.color = Color.red;
            gameOverText.text = "<b>RED WINS!</b>";
        }
        else if (bluePoints == redPoints)
        {
            gameOverText.color = Color.yellow;
            gameOverSub.color = Color.yellow;
            gameOverText.text = "<b>DRAW!</b>";
        }
    }

    //public void Reset()
    //{
    //    playing = true;
    //    gameOverScreen.SetActive(false);
    //    bluePoints = 0;
    //    redPoints = 0;
    //    time = gameDuration;
    //
    //    red.transform.position = redStart.position;
    //    red.transform.rotation = redStart.transform.rotation;
    //
    //    blue.transform.position = blueStart.position;
    //    blue.transform.rotation = blueStart.transform.rotation;
    //}
}
