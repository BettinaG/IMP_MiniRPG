using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public Rigidbody2D rb;
    public float movespeed = 5f;
    public bool moveRight;
    public bool moveLeft;
    public bool jump;
    public float jumpheight;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    void Update()
    {

        //Inputs für Maus und Tastatur
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);

        }
        if (grounded&&Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpheight);
        }

        //Inputs für Touch
        if (moveRight)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }
        if (moveLeft)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }
        if (grounded&&jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpheight);
            jump = false;
        }

    }
}
