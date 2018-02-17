using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderScript : MonoBehaviour {

    private Vector3 wayPoint;

    public WanderScript() { }

	public void Wander()
    {
        wayPoint = Random.insideUnitSphere * 5;
        wayPoint.y = 0.5f;
    }
}
