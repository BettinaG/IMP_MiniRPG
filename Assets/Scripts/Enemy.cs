using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {


    private GameObject enemy;

    private GameObject target;

    private int speed, walkingRange, hitPoints, damage;

    private Animator anim;

    private bool isMoving, isAttacking, isFollowing;
    private bool isInTransition;

    private bool playerInRange;

    private float spawnPoint;
    private float currentPosition;
    private bool walksRight;

    public Enemy(GameObject enemy, int speed, int walkingRange, int hitPoints, int damage, Animator anim)
    {

        this.enemy = enemy;
        this.speed = speed;
        this.walkingRange = walkingRange;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.anim = anim;

        isMoving = true;
        walksRight = true;
        spawnPoint = enemy.transform.position.x;
        currentPosition = spawnPoint;

        
        
    }

    public void Wander()
    {
        if (currentPosition < spawnPoint + walkingRange && walksRight)
        {
            currentPosition = currentPosition + 0.001f * speed;
            enemy.transform.position = new Vector3(currentPosition, enemy.transform.position.y, enemy.transform.position.z);
        }
        else if (currentPosition > spawnPoint - walkingRange && !walksRight)
        {
            currentPosition = currentPosition - 0.001f * speed;
            enemy.transform.position = new Vector3(currentPosition, enemy.transform.position.y, enemy.transform.position.z);
        }
        else if (currentPosition >= 1.3 && walksRight)
        {
            walksRight = false;
            enemy.transform.Rotate(0, 180, 0);
        }
        else if (currentPosition <= -0.2 && !walksRight)
        {
            walksRight = true;
            enemy.transform.Rotate(0, 180, 0);
        }
    }

    public void followTarget()
    {
        if (!playerInRange)
        {
            Debug.Log("FOLLLOOOWWW");
            if(currentPosition < target.transform.position.x)
            {
                if (!walksRight)
                {
                    enemy.transform.Rotate(0, 180, 0);
                    walksRight = true;
                }
                currentPosition = currentPosition + 0.001f * speed;
                enemy.transform.position = new Vector3(currentPosition, enemy.transform.position.y, enemy.transform.position.z);
            }
            else if(currentPosition > target.transform.position.x)
            {
                if (walksRight)
                {
                    enemy.transform.Rotate(0, 180, 0);
                    walksRight = false;
                }
                currentPosition = currentPosition - 0.001f * speed;
                enemy.transform.position = new Vector3(currentPosition, enemy.transform.position.y, enemy.transform.position.z);
            }
        }
    }

   public void attack()
   {
        Debug.Log("attackAttackAttack");
        anim.SetTrigger("isAttacking"); 
   }

    public float getCurrentPosition()
    {
        return currentPosition;
    }

    public bool moving()
    {
        return isMoving;
    }

    public void setMoving(bool moving)
    {
        isMoving = moving;
        anim.SetBool("isMoving", moving);
        
    }

    public bool playerIsInRange()
    {
        return playerInRange;
    }

    public void setPlayerInRange(bool inRange)
    {
        playerInRange = inRange;
    }

    public bool attacking()
    {
        return isAttacking;
    }

    public void setAttacking(bool attacking)
    {
        isAttacking = attacking;
    }

    public bool following()
    {
        return isFollowing;
    }

    public void setFollowing(bool following)
    {
        isFollowing = following;
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }

    private bool inTransition()
    {
        return isInTransition;
    }

    public void setIsInTransition()
    {
        isInTransition = anim.IsInTransition(0);
    }
}
