using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wanderScript : MonoBehaviour {

    private Vector3 wayPoint;

    public wanderScript() { }

	public void Wander()
    {
        wayPoint = Random.insideUnitSphere * 5;
        wayPoint.y = 0.5f;
    }
}
