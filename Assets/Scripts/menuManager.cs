using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject lastselect, playScreen, blueStart, redStart;
    gameManager GM;
    bool tutorial = false;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GM = this.GetComponent<gameManager>();
    }
    void Update()
    {
        if (tutorial == false)
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(lastselect);
            }
            else
            {
                lastselect = EventSystem.current.currentSelectedGameObject;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                playScreen.SetActive(false);
                tutorial = false;
            }

            if (Input.GetKey(KeyCode.D))
            {
                redStart.transform.localScale = Vector3.Lerp(redStart.transform.localScale, Vector3.zero, 0.05f);
            }
            else
            {
                redStart.transform.localScale = Vector3.Lerp(redStart.transform.localScale, Vector3.one, 0.2f);
            }

            if (Input.GetKey(KeyCode.L))
            {
                blueStart.transform.localScale = Vector3.Lerp(blueStart.transform.localScale, Vector3.zero, 0.05f);
            }
            else
            {
                blueStart.transform.localScale = Vector3.Lerp(blueStart.transform.localScale, Vector3.one, 0.2f);
            }

            if (blueStart.transform.localScale.magnitude < new Vector3(0.1f, 0.1f, 0.1f).magnitude &&
                redStart.transform.localScale.magnitude < new Vector3(0.1f, 0.1f, 0.1f).magnitude)
            {
                this.GetComponent<gameManager>().playing = true;
                this.GetComponent<gameManager>().started = true;
                SceneManager.LoadScene(1);
            }
        }
    }

    public void PlayGame()
    {
        playScreen.SetActive(true);
        tutorial = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
