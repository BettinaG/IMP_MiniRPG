using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject enemy;
    public int speed, walkingRange, hitPoints, damage;
    public Animator anim;

    private Enemy e;

    void Start () {

        e = new Enemy(enemy, speed, walkingRange, hitPoints, damage, anim);

	}
	
	// Update is called once per frame
	void Update () {
        e.Wander();
        e.setIsInTransition();
    }
}
