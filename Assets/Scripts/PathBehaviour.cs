using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBehaviour : MonoBehaviour {

    private void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
          //  bool success = collision.gameObject.GetComponent<PathCounter>().LoadPath();
            
        }
    }
}
