using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public int maxHealth = 40;
    private int curHealth;

    void Start()
    {
        curHealth = maxHealth; 
    }
    void Update () {
		if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
	}
    void Damage(int damage)
    {
        curHealth -= damage;
    }
}
