using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkController : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;

    public float maxSpeed = 5f;
    public float moveForce = 100f;   
    public float jumpForce = 1000f;
    float move = 0f;
    float attackOnce = 0f;
    float attackTime = 0.2f;

    public Transform groundCheck;
    private Rigidbody2D rb2d;

    private bool grounded = true;
    bool attack = false;


    Animator anim;

    // Use this for initialization
    void Start() {
       
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        print("ground: " + grounded);


        if (Input.GetButtonDown("Jump"))
        {
            //anim.SetTrigger("jumping");
            print("SALTA!");
            jump = true;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //anim.SetBool("ground", grounded);
        anim.SetFloat("speed", Mathf.Abs(move));
        anim.SetBool("attack", attack);
        anim.SetBool("jumping", jump);


        move = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        if (jump)
        {
            //anim.SetBool("ground", false);
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;

        }



        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (Input.GetKey(KeyCode.L))
        {
            attack = true;
            attackOnce = Time.time;
        }

        if ((Time.time - attackOnce) >= attackTime)
        {
            attack = false;
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
