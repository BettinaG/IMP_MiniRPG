using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWorld : MonoBehaviour {

    public float rotationSpeed;
    
	void Update () {
        transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
	}
}
