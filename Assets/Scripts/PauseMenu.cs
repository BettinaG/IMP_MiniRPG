using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Button resume;
    public Button restart;
    public Button mainMenu;
    public Button quit;

    private void Start()
    {
        resume = GameObject.Find("Resume").GetComponent<UnityEngine.UI.Button>();
        restart = GameObject.Find("Restart").GetComponent<UnityEngine.UI.Button>();
        mainMenu = GameObject.Find("Main Menu").GetComponent<UnityEngine.UI.Button>();
        quit = GameObject.Find("Quit").GetComponent<UnityEngine.UI.Button>();
    }
    private void Update()
    {
        resume.onClick.AddListener(() => Resume());
        restart.onClick.AddListener(() => Restart());
        mainMenu.onClick.AddListener(() => MainMenu());
        quit.onClick.AddListener(() => Quit());
    }
    public void Resume()
    {
        GameManager.INSTANCE.isPaused = false;
        GameManager.INSTANCE.Pause();
        Debug.Log("pause");
    }
    public void Restart()
    {
        HealthController.INSTANCE.curHealth = 5;
        GameManager.INSTANCE.points = 0;
        PlayerControllerScript.INSTANCE.gameObject.transform.position = new Vector3(0.5f, 0, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.INSTANCE.isPaused = false;
        GameManager.INSTANCE.Pause();
        HealthController.INSTANCE.isDead = false;
        HealthController.INSTANCE.isAlive = true;
        PlayerControllerScript.INSTANCE.stopMotion = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        GameManager.INSTANCE.isPaused = false;
        GameManager.INSTANCE.Pause();
        Destroy(GameManager.INSTANCE.gameObject);
        Destroy(UI.INSTANCE.gameObject);
        Destroy(PlayerControls.INSTANCE.gameObject);
        Destroy(PlayerControllerScript.INSTANCE.gameObject);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
