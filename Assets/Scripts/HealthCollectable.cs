using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.isTrigger != true && collider.CompareTag("Player"))
        {
            if(HealthController.INSTANCE.curHealth >= 5)
            {
                return;
            }
            else if(HealthController.INSTANCE.curHealth < 5)
            {
                HealthController.INSTANCE.curHealth += 1;
                Destroy(gameObject);
            }
        }
    }
}
