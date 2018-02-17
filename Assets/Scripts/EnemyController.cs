using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


    public GameObject enemy;
    public int speed, walkingRange, hitPoints, damage;
    public Animator anim;

    private Enemy e;

    private float timer;
    public float timeBetweenAttacks;

    void Start () {

        e = new Enemy(enemy, speed, walkingRange, hitPoints, damage, enemy.GetComponent<Animator>());
    }

    void Update () {
        timer += Time.deltaTime;

        if (e.moving())
        {
            if (!e.following())  e.Wander();
            else                 e.followTarget();
        }
        else if (e.attacking())
        {
            if (timer >= timeBetweenAttacks && e.playerIsInRange())
            {
                timer = 0;
                e.attack();
            }
        }
        e.setIsInTransition();

        Debug.Log("Moving: " + e.moving() + "               Attacking: " + e.attacking());

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("He entered");
            e.setPlayerInRange(true);
            e.setTarget(other.gameObject);


            e.setMoving(false);
            e.setAttacking(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("He left");
            e.setPlayerInRange(false);

            e.setAttacking(false);
            e.setMoving(true);
            e.setFollowing(true);
        }
    }
}
