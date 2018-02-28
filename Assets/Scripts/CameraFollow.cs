using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private float interpVelocity;
    [SerializeField]
    private float minDistance;
    [SerializeField]
    private float followDistance;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 targetPos;
    
    private void Start()
    {
        targetPos = transform.position;
    }
    private void LateUpdate()
    {
        if (PlayerControllerScript.INSTANCE.gameObject)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = PlayerControllerScript.INSTANCE.gameObject.transform.position.z;

            Vector3 targetDirection = (PlayerControllerScript.INSTANCE.gameObject.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 15f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }
    }
}