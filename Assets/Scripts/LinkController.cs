using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkController : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;

    public int health = 5;

    //movement
    public float maxSpeed = 3f;
    public float moveForce = 50f;
    public float jumpForce = 300f;
    float move = 0f;
    float attackOnce = 0f;
    float attackTime = 0.2f;
    public static int flip = -1;
    public float backForce;
    private float backTimer;

    public Transform groundCheck;
    private Rigidbody2D rb2d;


    private bool grounded = true;
    bool attack = false;
    bool dam = false;

    bool shield = false;

    Animator anim;

    //Weapons
    public GameObject Sword;
    private BoxCollider2D swordBox;


    //shooting
    //public GameObject bulletPrefab;
    private LineRenderer laser;
    int shootableMask;                     // A layer mask so the raycast only hits things on the shootable layer.
    private float range = 1000f;                      // The distance the gun can fire.

    private float timer = 0f;
    private float timeBetweenShoots = 0.1f;
    private float shootEffect = 0.05f;

    private AudioSource laserSound;

    private Light resplandor;


    // Use this for initialization
    void Awake()
    {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        swordBox = Sword.GetComponent<BoxCollider2D>();

    }

    private void Start()
    {
        shootableMask = LayerMask.GetMask("NPC");

        laser = GetComponent<LineRenderer>();
        laser.enabled = false;

        laserSound = GetComponent<AudioSource>();

        resplandor = GetComponentInChildren<Light>();
    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        print("ground: " + grounded);
        print("jump" + jump);




        if (Input.GetButtonDown("Jump") && grounded)
        {

            jump = true;

        }

        /* if (backTimer > 0)
         {
             backTimer -= Time.deltaTime;
         }*/

    }
    /*void ProcessInput()
    {
        rb2d.velocity = new Vector3(0, rb2d.velocity.y, 0);
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {


        anim.SetBool("ground", grounded);
        anim.SetFloat("speed", Mathf.Abs(move));
        anim.SetBool("attack", attack);
        anim.SetBool("dam", dam);

        //anim.SetBool("jumping", jump);


        move = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        if (jump)
        {
            //anim.SetTrigger("jumping");
            //anim.SetBool("ground", false);
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;

        }



        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (Input.GetButtonDown("Fire1"))
        //if (Input.GetKey(KeyCode.F))
        {
            SwordBoxAttack();
            attack = true;
            attackOnce = Time.time;

            Shoot();
        }

        if ((Time.time - attackOnce) >= attackTime)
        {
            attack = false;
            SwordBoxRetract();
            DisableShoot();
        }

        if (Input.GetKey(KeyCode.D))
        {
            shield = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        flip *= -1;
    }

    public void SwordBoxAttack()
    {
        swordBox.offset = new Vector2(0.9f, 0.6f);
        swordBox.size = new Vector2(1f, 0.4f);
    }

    public void SwordBoxRetract()
    {
        swordBox.offset = new Vector2(0f, 0f);
        swordBox.size = new Vector2(0.4f, 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyBullet>() != null)
        {
            Hit((transform.position - collision.transform.position).normalized);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Hit((transform.position - collision.transform.position).normalized);
        }
    }

    private void Hit(Vector2 direction)
    {
        anim.SetBool("dam", true);
        Vector2 backDirection = (direction).normalized;
        print(backDirection);
        rb2d.AddForce(backDirection * backForce);
        //rb2d.AddForce(new Vector2(direction.x * -600, direction.y * backForce));
        // backTimer = 1f;


        health--;
        if (health <= 0)
        {
            SceneManager.LoadScene("ZeldaRoom");
           // Destroy(gameObject);
            
        }

    }

    void Shoot()
    {

        laser.SetPosition(0, transform.position);

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootableMask);
         if (hit.collider != null)
         {
            laser.SetPosition(1, hit.point);
             laser.SetPosition(1, hit.point);
             Destroy(hit.collider.gameObject);
         }
         else
         {
             laser.SetPosition(1, transform.position + Vector3.forward * range);
         }

        laser.enabled = true;

        resplandor.enabled = true;
        //laserSound.Play();
        timer = 0f;

      
    }

    void DisableShoot()
    {
        timer = 0f;
        laser.enabled = false;
        resplandor.enabled = false;
    }
}    
