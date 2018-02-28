using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    public static PlayerControllerScript INSTANCE; 

    public float maxSpeed = 10f;
    public float moveSpeed = 5f;
    public float jumpForce = 18f;
    public bool moveRight = false;
    public bool moveLeft = false;
    public bool jump;
    public float jumpHeight = 5.5f;
    public bool attacking = false;
    public float attackTimer = 0;
    public float attackCd = 0.01f;
    public bool stopMotion;

    public Transform groundCheck;
    public Collider2D attackTrigger;
    public LayerMask whatIsGround;

    private float groundRadius = 0.2f;
    private bool grounded = false;
    private float move;
    private bool facingRight = true;

    private Rigidbody2D rigidbody2d;
    private Animator anim;
    private GameManager gm;

    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
    private void Start () {
        stopMotion = false;
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attackTrigger.enabled = false;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
        if (!stopMotion)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

            move = Input.GetAxis("Horizontal");

            anim.SetBool("Ground", grounded);
            anim.SetFloat("Speed", Mathf.Abs(move));
            anim.SetFloat("vSpeed", rigidbody2d.velocity.y);
            anim.SetBool("Attacking", attacking);

            rigidbody2d.velocity = new Vector2(move * maxSpeed, rigidbody2d.velocity.y);
            
            if (Input.GetKeyDown("f") && !attacking)
            {
                attacking = true;
                attackTimer = attackCd;

                attackTrigger.enabled = true;
            }
            if (attacking)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    attacking = false;
                    attackTrigger.enabled = false;
                }
            }
            //Unity Controls
#if UNITY_STANDALONE || UNITY_PLAYER || UNITY_EDITOR

            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
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
    }
    private void Update()
    {
        if (!stopMotion)
        {
            if (grounded && Input.GetButton("Jump"))
            {
                anim.SetBool("Ground", false);
                rigidbody2d.AddForce(new Vector2(0, jumpForce));
            }
        }
        
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Rubberduck"))
        {
            Destroy(collider.gameObject);
            gm.points += 1;
        }
    }
}
