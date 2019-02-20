using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterStats))]
public class LinkController : MonoBehaviour {

    
    [HideInInspector] public bool grounded = false;
    [HideInInspector] public bool crouch;
    [HideInInspector] public bool attack = false;
    [HideInInspector] public float move = 0;
    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool facingRight = true;

    public LayerMask WhatIsGround;
    public Transform groundCheck;


    private float groundRadius = 0.05f;
    private float attackOnce = 0f;
    private float attackTime = 0.2f;


    private bool movement = false;
    
    public float maxSpeed = 10f;
    public float jumpForce = 300f;

    protected Rigidbody2D rb2d;

    CharacterStats myStats;
    LiftScript lift;
    Collider2D liftCollider;

    /*public GameObject link;
	public GameObject Shield;
	public GameObject Sword;*/
    public GameObject blade;

    public BoxCollider2D linkBox;
    public BoxCollider2D shieldBox;
    public BoxCollider2D swordBox;

    public static LinkController instance;

    void Start (){

        instance = this;
		/*linkBox = link.GetComponent<BoxCollider2D>();
		shieldBox = Shield.GetComponent<BoxCollider2D>();
		swordBox = Sword.GetComponent<BoxCollider2D>();  */    
        rb2d = GetComponent<Rigidbody2D>();
        myStats = GetComponent<CharacterStats>();
       
        lift = FindObjectOfType<LiftScript>();
        if(lift != null)
        {
            liftCollider = lift.GetComponent<Collider2D>();
        }
       
    }

    public void FixedUpdate () 
	{
        /*This checks if Link is on the ground which is used by the jump and crouch animations*/
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGround);

        if (movement == true) {
			move = Input.GetAxis ("Horizontal");
			GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (movement == false) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);
			move = 0;
		}

        crouch = Input.GetKey("down");

        if (!crouch)
        {
            linkBox.size = new Vector2(1.0f, 1.9f);
            shieldBox.offset = new Vector2(0.0f, 0.0f);
            linkBox.offset = new Vector2(0.0f, 0.0f);
            movement = true;          
        }
        else {
            movement = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            move = 0;
            ColliderCrouch();
        }
	

		if ((GetComponent<Rigidbody2D>().velocity.y)> 0) {            
            
            if (crouch/* && grounded && !attack*/){
				movement = false;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);
				move = 0;
			}else{
				movement = true;
				move = Input.GetAxis ("Horizontal");
			}
		}

        if(liftCollider != null)
         {
            if (rb2d.IsTouching(liftCollider))
            {
                grounded = true;
            }
        }

    }

    // Update is called once per frame
    public void Update()
	{
        if (grounded && Input.GetButtonDown("Jump"))
        {            
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce));
          
            jump = true;  //DarkLink Animation

            AudioManager.instance.PlaySound("Jumping", transform.position);
          
        }
        else
        {
            jump = false;
        }



        if (Input.GetKeyDown(KeyCode.F) && !crouch)
        {
            SwordBoxAttack();

            attack = true;           

            attackOnce = Time.time;
            if (myStats.health == 5) StartCoroutine(Wait());

            AudioManager.instance.PlaySound("Sword", transform.position);
           
        }	       


        if ((Time.time - attackOnce) >= attackTime) {
            
            attack = false;
            SwordBoxRetract();          
		}     
        
        

    }
	
	

    public void SwordBoxAttack()
    {
        swordBox.offset = new Vector2(2.0f, 0.47f);
        swordBox.size = new Vector2(3f, 0.25f);
    }

    public void SwordBoxRetract()
    {
        swordBox.offset = new Vector2(0f, 0f);
        swordBox.size = new Vector2(0.4f, 0.4f);
    }
  

    public void ColliderCrouch()
	{
        linkBox.size = new Vector2(1.0f, 1.7f);
        linkBox.offset = new Vector2(0.0f, -0.12f);
        shieldBox.offset = new Vector2(0.2f, -0.23f);
    }
    
   
      
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject b;
        AudioManager.instance.PlaySound("Blade", transform.position);

        if (facingRight)
        {
            
            blade.GetComponent<SpriteRenderer>().flipX = false;
            b = Instantiate(blade, transform.position + new Vector3(1.2f, 0.28f, 0f), Quaternion.identity);
            b.GetComponent<Rigidbody2D>().AddForce(new Vector3(1f, 0f, 0f) * 500);           

        }
        else
        {          
            blade.GetComponent<SpriteRenderer>().flipX = true;
            b = Instantiate(blade, transform.position - new Vector3(1f, -0.3f, 0f), Quaternion.identity);
            b.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1f, 0f, 0f) * 500);
          
        }
       
    }
}