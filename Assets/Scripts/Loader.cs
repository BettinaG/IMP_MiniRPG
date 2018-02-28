using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject player;
    public GameObject ui;
    public GameObject pc;
    public GameObject gm;
    public GameObject eventSystem;

    void Awake()
    {
        if(GameManager.INSTANCE == null)
        {
            Instantiate(gm);
        }
        if (UI.INSTANCE == null)
        {
            Instantiate(ui);
        }
        if (PlayerControls.INSTANCE == null)
        {
            Instantiate(pc);
        }
        if (Eventsystem.INSTANCE == null)
        {
            Instantiate(eventSystem);
        }
        if (PlayerControllerScript.INSTANCE == null)
        {
            Instantiate(player);
        }
    }
}
