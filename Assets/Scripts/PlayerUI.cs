using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerUI : MonoBehaviour {

    //Singleton Instance
    public static PlayerUI INSTANCE;

    [Header("Health UI")]
    [Tooltip("First Pumpkin Life")]
    public Image life1;
    [Tooltip("Second Pumpkin Life")]
    public Image life2;
    [Tooltip("Third Pumpkin Life")]
    public Image life3;

    private Color messageTextDefaultColor;
    private bool showMessage;

	// Use this for initialization
	void Awake () {
        INSTANCE = this;
    }

    public void SetHealth(int currentHealth)
    {
        switch(currentHealth)
        {
            case 3:
                life1.fillAmount = 1;
                break;
            case 2:
                life1.fillAmount = 0;
                life2.fillAmount = 1;
                break;
            case 1:
                life2.fillAmount = 0;
                life3.fillAmount = 1;
                break;
            case 0:
                life3.fillAmount = 0;
                break;
        }
    }

}
