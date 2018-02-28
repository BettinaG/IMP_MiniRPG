using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
    
    public GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning
    public int dmg = 1;
    public int curHealth;
    public int maxHealth = 2;



    void Start()
    {
        curHealth = maxHealth;
    }
    void Update ()
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
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.isTrigger != true && collider.CompareTag("Player"))
        {
            collider.SendMessageUpwards("TakeDamage", dmg);
        }
    }
    public void TakeDamage(int dmg)
    {
        curHealth -= dmg;
    }

}
