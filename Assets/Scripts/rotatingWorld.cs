using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWorld : MonoBehaviour {

    public float rotationSpeed;
    
	private void Update () {
        transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
	}
}
