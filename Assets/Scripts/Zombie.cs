using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
    
    public GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning
    public int dmg = 1;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update ()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.isTrigger != true && collider.CompareTag("Player"))
        {
            collider.SendMessageUpwards("TakeDamage", dmg);
        }
    }

}
