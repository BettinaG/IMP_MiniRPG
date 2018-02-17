using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public float maxHealth;
    public bool isPlayer;

    private float currentHealth;
    public bool isAlive { get; set; }
    private bool isVulnerable;

    void Start()
    {
        currentHealth = maxHealth;
        isAlive = true;
        isVulnerable = true;
    }

    public void TakeDamage(float damage)
    {
        if (isVulnerable)
            currentHealth -= damage;
        if (isPlayer)
        {
            PlayerUI.INSTANCE.SetHealth((int)currentHealth);
        }
        if(currentHealth <= 0 && isAlive)
        {
            currentHealth = 0;
            Die();
        }
    }
    private void Die()
    {
        if(gameObject.tag.Equals("Player"))
        {
            gameObject.GetComponent<CharController>().isDying = true;
        }
    }
}
