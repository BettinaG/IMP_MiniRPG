using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public bool isPlayer;
    public int curHealth;
    public int maxHealth = 5;
    public bool isAlive;
    public bool isDying;
    public bool isDead;


    private GameManager gm;
    private Animator anim;
    private PlayerControllerScript player;

    void Start()
    {
        isDead = false;
        isDying = false;
        isAlive = true;
        curHealth = maxHealth;
        anim = GetComponent<Animator>();
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerControllerScript>();
    }
    void Update()
    {
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if(curHealth <= 0)
        {
            isDying = true;

        }
        if (isDying)
        {

            isAlive = false;
            Die();
            isDying = false;
            
        }
    }
    void Die()
    {
        if (!isAlive && !isDead)
        {
            if (isPlayer)
            {
                gameObject.GetComponent<PlayerControllerScript>().stopMotion = true;
                StartCoroutine(HandleGameOver());
                isDead = true;
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
    IEnumerator HandleGameOver()
    {
        anim.SetTrigger("dies");
        Debug.Log("Tod");
        yield return new WaitForSeconds(5f);
        gm.Restart();
    }
}
