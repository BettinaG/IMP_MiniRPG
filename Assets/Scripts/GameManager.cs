using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager INSTANCE;

    //public GameObject PauseUI;
    //public GameObject PlayerControls;

    public int points;
    public Text pointsText;
    public Text doorText;

    public bool paused = false;


    void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {

        PlayerControls.INSTANCE.Controls.SetActive(true);
        UI.INSTANCE.pUI.SetActive(false);

        UI.INSTANCE.doorText.text = ("");
    }
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }
        if (paused)
        {
            PlayerControls.INSTANCE.Controls.SetActive(false);
            UI.INSTANCE.pUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PlayerControls.INSTANCE.Controls.SetActive(true);
            UI.INSTANCE.pUI.SetActive(false);
            Time.timeScale = 1;
        }
        UI.INSTANCE.pointsText.text = ("" + points);
    }

    public void Resume()
    {
        paused = false;
    }
    public void Restart()
    {
        HealthController.INSTANCE.curHealth = 5;
        GameManager.INSTANCE.points = 0;
        PlayerControllerScript.INSTANCE.gameObject.transform.position = new Vector3(0.5f, 0, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.INSTANCE.paused = false;
        HealthController.INSTANCE.isDead = false;
        HealthController.INSTANCE.isAlive = true;
        PlayerControllerScript.INSTANCE.stopMotion = false;
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
