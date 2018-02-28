using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour {

    private GameManager gm;
    private PlayerControllerScript player;

    public int loadLevel;
    public bool isCastle;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>();

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            UI.INSTANCE.doorText.text = ("Press 'Attack' to enter");
            if (isCastle)
            {
                if(player.attacking && gm.points >= 100)
                {
                    SceneManager.LoadScene(loadLevel);
                }
                else if (player.attacking && gm.points < 100)
                {
                    UI.INSTANCE.doorText.text = ("You need 100 Rubberducks to pass!");
                }
            }
            else
            {
                if (player.attacking)
                {
                    SceneManager.LoadScene(loadLevel);
                }
            }
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (isCastle)
            {
                if (player.attacking && gm.points >= 100)
                {
                    SceneManager.LoadScene(loadLevel);
                    UI.INSTANCE.doorText.text = ("");
                }
                else if (gm.points < 100)
                {
                    UI.INSTANCE.doorText.text = ("You need 100 Rubberducks to pass!");
                }
            }
            else
            {
                if (player.attacking)
            {
                    SceneManager.LoadScene(loadLevel);
                    UI.INSTANCE.doorText.text = ("");
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        UI.INSTANCE.doorText.text = ("");    
    }
}
