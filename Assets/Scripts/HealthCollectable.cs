using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.isTrigger && collider.CompareTag("Player") && HealthController.INSTANCE.curHealth < 5)
        {
                HealthController.INSTANCE.curHealth += 1;
                Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
