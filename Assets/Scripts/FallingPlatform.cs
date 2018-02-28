using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    public Rigidbody2D rb2d;

    private void Start()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.isTrigger && collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(1f);
        rb2d.constraints = RigidbodyConstraints2D.None;
    }
}
