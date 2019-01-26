using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkController : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;

    public int health = 5;
    public int live = 3;

    //movement
    public float maxSpeed = 3f;
    public float moveForce = 50f;
    public float jumpForce = 300f;
    public float move = 0f;
    private bool movement;

    float attackOnce = 0f;
    float attackTime = 0.2f;
    public static int flip = -1;
    public float backForce;
    private float backTimer;

    public Transform groundCheck;
    private Rigidbody2D rb2d;


    public bool grounded = true;
    public bool attack = false;
    bool dam = false;
    public bool crouch = false;

    bool shield = false;

    public Animator anim;

    //Weapons
    public GameObject Sword;
    public GameObject Shield;
    private BoxCollider2D swordBox;
    private BoxCollider2D shieldBox;
    public GameObject blade;


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
        shieldBox = Shield.GetComponent<BoxCollider2D>();

    }

    private void Start()
    {
        shootableMask = LayerMask.GetMask("NPC");

        laser = GetComponent<LineRenderer>();
        laser.enabled = false;

        laserSound = GetComponent<AudioSource>();

        resplandor = GetComponentInChildren<Light>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            attack = true;
            attackOnce = Time.time;
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {    
        /*This checks if link is close to the ground to activate the crouch animation when Link lands.
		 It does a linecast which acts like a collider set as a trigger in a way.*/
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));


        /*These are the variables the Animator accesses.*/
        anim.SetBool("ground", grounded);
        anim.SetFloat("speed", Mathf.Abs(move));
        anim.SetBool("attack", attack);
        anim.SetBool("dam", dam);
        anim.SetBool("crouch", crouch);
        //anim.SetBool("jumping", jump);

        if (movement == true)
        {
            move = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            move = 0;
        }       


        if (Input.GetButtonDown("Jump") && grounded)
        {
            //anim.SetTrigger("jumping");
            //anim.SetBool("ground", false);
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = true;

        }
        else
        {
            jump = false;
        }

        if (Input.GetKey("down"))
        {
            anim.SetTrigger("crouch");
            ShieldBoxAttack();
            crouch = true;
            movement = false;            
        }
        else
        {
           ShieldBoxRetract();
            crouch = false;
            movement = true;           
        }


        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        /* if (Input.GetButtonDown("Fire1"))
         //if (Input.GetKey(KeyCode.F))
         {
             SwordBoxAttack();
             attack = true;
             attackOnce = Time.time;
             //Shoot();
             print("attackOnce " + attackOnce);
             print(Time.time);
             GameObject t = (GameObject)Instantiate(blade, transform.position, Quaternion.identity);

            /* GameObject t = Instantiate(blade);
             t.transform.position = transform.position + transform.forward;
             t.transform.forward = transform.forward;/
             t.GetComponent<Rigidbody2D>().AddForce(transform.forward * 10);
             Destroy(t, 3);

         }   



         if ((Time.time - attackOnce) >= attackTime)
         {
             attack = false;
             SwordBoxRetract();
             //DisableShoot();

         }*/

        if (Input.GetButtonDown("Fire1"))
        {        
            SwordBoxAttack();
                attack = true;
                attackOnce = Time.time;

            if (health == 5)
            {
                StartCoroutine(Wait());
            }
           
        }

        if ((Time.time - attackOnce) >= attackTime)
        {
            attack = false;
            SwordBoxRetract();
            //DisableShoot();


        }
        
            if (Input.GetKey(KeyCode.D))
        {
            shield = true;
        }

        if (health <= 0)
        {
            live--;
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            // Destroy(gameObject);

        }

        if (live <= 0)
        {
            SceneManager.LoadScene("ZeldaRoom");
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

    public void ShieldBoxAttack()
    {
        shieldBox.offset = new Vector2(0.55f, -0.8f);
        shieldBox.size = new Vector2(0.8f, 3.2f);
    }

    public void ShieldBoxRetract()
    {
        shieldBox.offset = new Vector2(0f, 0f);
        shieldBox.size = new Vector2(0.7f, 1.6f);
    }

    private void OnTriggerEnter2D(Collider2D collision )
    {
        if (collision.GetComponent<EnemyBullet>() != null && crouch == false)
        {
            Hit((transform.position - collision.transform.position).normalized);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null && crouch == false)
        {
            Hit((transform.position - collision.transform.position).normalized);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Hit((transform.position - collision.transform.position).normalized);

        }

        if (collision.gameObject.name == "lava")
        {
            health = 0;
        }
    }

    

    public void Hit(Vector3 direction)
    {
        anim.SetBool("dam", true);
        Vector2 backDirection = (direction).normalized;
        print(backDirection);
        rb2d.AddForce(backDirection * backForce);
        //rb2d.AddForce(new Vector2(direction.x * -600, direction.y * backForce));
        // backTimer = 1f;


        health--;      


    }

    void Shoot()
    {

        laser.SetPosition(0, transform.position + new Vector3(1.3f,0.2f,0f));

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootableMask);
         if (hit.collider != null)
         {
           
             laser.SetPosition(1, hit.point);
             Destroy(hit.collider.gameObject);
         }
         else
         {
             laser.SetPosition(1, transform.position + Vector3.forward * range);
         }

        laser.enabled = true;

        //resplandor.enabled = true;
        //laserSound.Play();
        timer = 0f;

      
    }

    void DisableShoot()
    {
        timer = 0f;
        laser.enabled = false;
        //resplandor.enabled = false;
    }

    IEnumerator Wait()
    {
       
        yield return new WaitForSeconds(0.15f);
        
        GameObject b;
     
        if (facingRight)
        {
            blade.GetComponent<SpriteRenderer>().flipX = true;
            b = Instantiate(blade, transform.position + new Vector3(1.3f, 0.3f, 0f), Quaternion.identity);
            b.GetComponent<Rigidbody2D>().AddForce(new Vector3(1f, 0f, 0f) * 500);
            Destroy(b, 3);
            
        }
        else
        {
            blade.GetComponent<SpriteRenderer>().flipX = false;
            b = Instantiate(blade, transform.position - new Vector3(1.3f, -0.3f, 0f), Quaternion.identity);
            b.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1f, 0f, 0f) * 500);
            Destroy(b, 3);
        }
    }
}    
