using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;
    private Rigidbody2D rigidbody2d;
    private float move;
    public float moveSpeed = 5f;

    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 18f;
    public bool moveRight = false;
    public bool moveLeft = false;
    
	void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
    //Hier steht das Zeug wie ich mein Character bewegen kann an der Tastatur
#if UNITY_STANDALONE || UNITY_PLAYER || UNITY_EDITOR
    void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);


        move = Input.GetAxis("Horizontal");
        
        anim.SetBool("Ground", grounded);
        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetFloat("vSpeed", rigidbody2d.velocity.y);

        rigidbody2d.velocity = new Vector2(move * maxSpeed, rigidbody2d.velocity.y);

        if(move > 0 && !facingRight)
        {
            Flip();
        }else if(move<0 && facingRight)
        {
            Flip();
        }
    }
    //Hier soll das rein was in Control.cs steht für die Mobile inputs.
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
    void FixedUpdate () {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2d.velocity = new Vector2(-movespeed, rigidbody2d.velocity.y);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2d.velocity = new Vector2(movespeed, rigidbody2d.velocity.y);

        }

        if (moveRight)
        {
            rigidbody2d.velocity = new Vector2(movespeed, rigidbody2d.velocity.y);
        }
        if (moveLeft)
        {
            rigidbody2d.velocity = new Vector2(-movespeed, rigidbody2d.velocity.y);
        }
    }
#endif
    void Update()
    {
        if(grounded && Input.GetButton("Jump")){
            anim.SetBool("Ground", false);
            rigidbody2d.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
