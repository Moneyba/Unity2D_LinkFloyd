using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;

    //public GameObject bullet;


    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        print(grounded);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            anim.SetTrigger("jumping");
            print("SALTA!");
            jump = true;

        }
    }



    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        //anim.SetFloat("xvel", Mathf.Abs(h));
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
       // anim.SetBool("jumping", jump);
        print("h" + h);
        print(rb2d.velocity.x);

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);


        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);


        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {

            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;

        }
        /*
                if (Input.GetButtonDown("Fire1")) 
                {
                    GameObject b;


                    if (facingRight)
                    {
                        b = Instantiate(bullet, transform.position + transform.right * 1f, Quaternion.identity);
                        b.GetComponent<Rigidbody2D>().AddForce(new Vector3(1f, 0.2f, 0f) * 1000);
                    }
                    else
                    {
                        b = Instantiate(bullet, transform.position - transform.right * 1f, Quaternion.identity);
                        b.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1f, 0.5f, 0f) * 1000);
                    }             

                    //Instantiate(bullet, transform.position + transform.up* 1.5f, Quaternion.identity);
                    //bullet.transform.position += new Vector3(0.05f, 0f, 0f);


                }*/

        // Set animator variables

        //anim.SetBool("jumping", jump);



    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}

