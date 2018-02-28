using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.isTrigger && collider.CompareTag("Player"))
        {
            GameManager.INSTANCE.Restart();
        }
    }
}
