using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubberDuckEnemy : MonoBehaviour
{
    public int ducks;
    public int count;

    public GameObject[] bubbles;

    private GameManager gm;
    private PlayerControllerScript player;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>();

        //Default Bubble 0:
        for (int i = 0; i < bubbles.Length; i++)
        {
            bubbles[i].SetActive(i == 0);
        }
    }
    private IEnumerator HandleDeath()
    {
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(2f);
        gm.points += ducks;
        Destroy(gameObject);

    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.isTrigger != true && collider.CompareTag("Player") && player.attacking)
        {
            count++;
            if (count == 20)
            {
                StartCoroutine(HandleDeath());
            }
            else if (count > 20)
            {
                Debug.Log("Zu viel!");
            }
            else
            {
                RandomBubble();
            }

        }
    }
    private void RandomBubble()
    {
        int number = Random.Range(0, 5);
        for (int i = 0; i < bubbles.Length; i++)
        {
            bubbles[i].SetActive(i == number);
        }
    }
}