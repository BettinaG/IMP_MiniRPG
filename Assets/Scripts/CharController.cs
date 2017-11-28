using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private Animation anim;
    private bool looksRight;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animation>();
        looksRight = true;
    }

    void Update()
    {
        
        if (controller.isGrounded)
        {
            if(looksRight)  moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"));
            else            moveDirection = new Vector3(0, 0, -Input.GetAxis("Horizontal"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetMouseButton(0))                                                   // ANGRIFF
        {
            anim.Play("Attack");
        }
        else if (Input.GetKey("d") && !anim.IsPlaying("Attack"))                      // NACH RECHTS LAUFEN
        {
            if (!looksRight)
            {
                transform.Rotate(0, 180, 0);
                looksRight = true;
            }
            anim.Play("Walk");
        }
        else if (Input.GetKey("a") && !anim.IsPlaying("Attack"))                     // NACH LINKS LAUFEN
        {
            if (looksRight)
            {
                transform.Rotate(0, 180, 0);
                looksRight = false;
            }
            anim.Play("Walk");
        }
       
        else if (!anim.isPlaying)                                                   // IDLE
        {
            anim.Play("Wait");
        }
        
    }
   
}
