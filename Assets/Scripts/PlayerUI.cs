using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerUI : MonoBehaviour {

    public Sprite[] PumpkinSprites;

    public Image PumpkinUI;

    private PlayerControllerScript player;
    private HealthController pHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>();
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
    }
    void Update()
    {
        PumpkinUI.sprite = PumpkinSprites[pHealth.curHealth];
    }
}
