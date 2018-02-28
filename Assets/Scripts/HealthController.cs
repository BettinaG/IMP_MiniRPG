using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public static HealthController INSTANCE;

    public bool isPlayer;
    public int curHealth;
    public int maxHealth = 5;
    public bool isAlive;
    public bool isDying;
    public bool isDead;
    public bool isVulnerable;


    [SerializeField]
    private Vector2 knockBackForce;

    private GameManager gm;
    private Animator anim;
    private PlayerControllerScript player;
    private Rigidbody2D rb2d;

    void Awake()
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
    void Start()
    {
        isVulnerable = true;
        isDead = false;
        isDying = false;
        isAlive = true;
        curHealth = maxHealth;
        anim = GetComponent<Animator>();
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerControllerScript>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (isDying)
        {
            isAlive = false;
            Die();
            isDying = false;
        }
    }
    void Die()
    {
        if (!isAlive && !isDead)
        {
            if (isPlayer)
            {
                gameObject.GetComponent<PlayerControllerScript>().stopMotion = true;
                StartCoroutine(HandleGameOver());
                isDead = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    IEnumerator HandleGameOver()
    {
        anim.SetTrigger("dies");
        yield return new WaitForSeconds(5f);
        gm.Restart();
    }
    public void TakeDamage(int dmg)
    {
        if(isVulnerable)
            curHealth -= dmg;
        if(curHealth <= 0 && isAlive)
        {
            curHealth = 0;
            isDying = true;
            isAlive = false;
        }
        if (isAlive && isPlayer)
        {
            StartCoroutine(Knockback());
        }
        
    }
    public IEnumerator Knockback()
    {
        isVulnerable = false;
        anim.SetTrigger("vulnerable");
        rb2d.AddForce(knockBackForce, ForceMode2D.Impulse);
        while(rb2d.velocity != Vector2.zero)
        {
            yield return null;
        }
        isVulnerable = true;

        
    }
    
}
