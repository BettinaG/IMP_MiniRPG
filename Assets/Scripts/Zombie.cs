using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public int maxHealth = 40;
    public GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning

    private Rigidbody2D rb;
    private int curHealth;

    void Start()
    {
        curHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update () {
		if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
        //rotate to look at the player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);
        //move towards the player
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
    void Damage(int damage)
    {
        curHealth -= damage;
    }
}
