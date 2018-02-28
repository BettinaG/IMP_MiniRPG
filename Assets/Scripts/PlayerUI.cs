using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerUI : MonoBehaviour {

    public static PlayerUI INSTANCE;
    public Sprite[] PumpkinSprites;
    public Image PumpkinUI;

    private void Awake()
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
    private void Update()
    {
        if(HealthController.INSTANCE.curHealth < 0)
        {
            HealthController.INSTANCE.curHealth = 0;
        }
        UI.INSTANCE.health.sprite = PumpkinSprites[HealthController.INSTANCE.curHealth];
    }
}
