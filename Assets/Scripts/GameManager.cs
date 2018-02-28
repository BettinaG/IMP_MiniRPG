using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager INSTANCE;

    public GameObject PauseUI;
    public GameObject PlayerControls;

    public int points;
    public Text pointsText;
    public Text doorText;

    public bool paused = false;

    void Start()
    {
        PlayerControls.SetActive(true);
        PauseUI.SetActive(false);

        doorText.text = ("");
    }
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }
        if (paused)
        {
            PlayerControls.SetActive(false);
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PlayerControls.SetActive(true);
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
        pointsText.text = ("" + points);
    }
    public void Resume()
    {
        paused = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
