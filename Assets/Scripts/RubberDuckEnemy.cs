using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubberDuckEnemy : MonoBehaviour {

    public int ducks;
    public int count;

    public GameObject bubble0;
    public GameObject bubble1;
    public GameObject bubble2;
    public GameObject bubble3;
    public GameObject bubble4;
    public GameObject bubble5;

    private GameManager gm;
    private PlayerControllerScript player;
    private Animator anim; 

    void Start()
    {
        anim = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>();
        bubble0.SetActive(true);
        bubble1.SetActive(false);
        bubble2.SetActive(false);
        bubble3.SetActive(false);
        bubble4.SetActive(false);
        bubble5.SetActive(false);
    }
    IEnumerator HandleDeath()
    {
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(2f);
        gm.points += ducks;
        Destroy(gameObject);

    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.isTrigger != true && collider.CompareTag("Player") && player.attacking)
        {
            count++;
            if(count == 20)
            {
                StartCoroutine(HandleDeath());
            }
            else if(count > 20)
            {
                Debug.Log("Zu viel!");
            }
            else
            {
                int zahl = Random.Range(0, 5);
                switch (zahl)
                {
                    case 4:
                        bubble1.SetActive(false);
                        bubble3.SetActive(false);
                        bubble4.SetActive(false);
                        bubble5.SetActive(false);
                        bubble0.SetActive(false);
                        bubble2.SetActive(true);
                        break;
                    case 3:
                        bubble2.SetActive(false);
                        bubble3.SetActive(false);
                        bubble4.SetActive(false);
                        bubble5.SetActive(false);
                        bubble0.SetActive(false);
                        bubble1.SetActive(true);
                        break;
                    case 2:
                        bubble1.SetActive(false);
                        bubble2.SetActive(false);
                        bubble4.SetActive(false);
                        bubble5.SetActive(false);
                        bubble0.SetActive(false);
                        bubble3.SetActive(true);
                        break;
                    case 1:
                        bubble1.SetActive(false);
                        bubble2.SetActive(false);
                        bubble3.SetActive(false);
                        bubble5.SetActive(false);
                        bubble0.SetActive(false);
                        bubble4.SetActive(true);
                        break;
                    case 0:
                        bubble1.SetActive(false);
                        bubble2.SetActive(false);
                        bubble3.SetActive(false);
                        bubble4.SetActive(false);
                        bubble0.SetActive(false);
                        bubble5.SetActive(true);
                        break;
                    default:
                        bubble0.SetActive(true);
                        break;
                }
            }
            
        }
    }
}
