 using UnityEngine;
 using System.Collections;
 public class DarkLinkController : Enemy
{
     
    [HideInInspector] public bool facingRight = true;
    private Rigidbody2D rb2d;
    private Animator animation;
    float move = 0;
    public float maxSpeed = 5;

    public LinkControllerScript link;
    
    public static int flip = -1;
    
    private bool dam = false;

    public GameObject DarkLink;
    public GameObject Shield;
    public GameObject Sword;

    private BoxCollider2D linkBox;
    private BoxCollider2D shieldBox;
    private BoxCollider2D swordBox;

    void Awake()
    {

        rb2d = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();

        linkBox = DarkLink.GetComponent<BoxCollider2D>();
        shieldBox = Shield.GetComponent<BoxCollider2D>();
        swordBox = Sword.GetComponent<BoxCollider2D>();

    }   
    

    void FixedUpdate()
    {
        animation.SetBool("Attack", link.attack);
        animation.SetBool("Ground", link.grounded);
        animation.SetFloat("Speed", Mathf.Abs(move));
        animation.SetBool("Dam", dam);
        animation.SetBool("Crouch", link.crouch);
        animation.SetFloat("vSpeed", link.GetComponent<Rigidbody2D>().velocity.y);

        move = -link.move;
        rb2d.velocity = new Vector2(move * maxSpeed, link.GetComponent<Rigidbody2D>().velocity.y);

        //transform.position = new Vector2(transform.position.x, link.transform.position.y);
        if (link.jump)
        {
            rb2d.AddForce(new Vector2(0f, link.jumpForce));           
            
        }        
        
       
        if (move < 0 && facingRight)
            Flip();
        else if (move > 0 && !facingRight)
            Flip();

        
        shieldBox.offset = link.shieldBox.offset;
        linkBox.size = link.linkBox.size;
        linkBox.offset = link.linkBox.offset;


    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        flip *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Sword")
        {
            
            animation.SetBool("Dam", true);
            animation.SetBool("Attack", false);
            base.Hit((transform.position - collision.transform.position).normalized);
           
        }

    }
}