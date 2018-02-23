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
    public bool jump;
    public float jumpHeight = 5.5f;
    public bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.01f;
    public Collider2D attackTrigger;


    void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attackTrigger.enabled = false;
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        move = Input.GetAxis("Horizontal");

        anim.SetBool("Ground", grounded);
        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetFloat("vSpeed", rigidbody2d.velocity.y);
        anim.SetBool("Attacking", attacking);
        //Unity Controls
#if UNITY_STANDALONE || UNITY_PLAYER || UNITY_EDITOR

        rigidbody2d.velocity = new Vector2(move * maxSpeed, rigidbody2d.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
        if(Input.GetKeyDown("f")&& !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }
        if (attacking)
        {
            if(attackTimer> 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        if (attacking)
        {

        }
        //Mobile Controls
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2d.velocity = new Vector2(moveSpeed, rigidbody2d.velocity.y);

        }

        if (grounded && Input.GetKey(KeyCode.Space))
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpHeight);
        }

        if (moveRight)
        {
            if (!facingRight) Flip();

            rigidbody2d.velocity = new Vector2(moveSpeed, rigidbody2d.velocity.y);
            float i = 1;
            anim.SetFloat("Speed", Mathf.Abs(i));
        }

        if (moveLeft)
        {
            if (facingRight) Flip();

            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            float i = 1;
            anim.SetFloat("Speed", Mathf.Abs(i));
        }
        if (grounded && jump)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpHeight);
            jump = false;
        }
        
#endif
    }
    void Update()
    {
        if (grounded && Input.GetButton("Jump"))
        {
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
