using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
    
    public int dmg = 1;
    public int curHealth;
    public int maxHealth = 2;

    private void Start()
    {
        curHealth = maxHealth;
    }
    private void Update ()
    {
            if (curHealth > maxHealth)
            {
                curHealth = maxHealth;
            }
            if (curHealth <= 0)
            {
                Destroy(gameObject);
            }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.isTrigger && collider.CompareTag("Player"))
        {
            collider.SendMessageUpwards("TakeDamage", dmg);
        }
    }
    public void TakeDamage(int dmg)
    {
        curHealth -= dmg;
    }

}
