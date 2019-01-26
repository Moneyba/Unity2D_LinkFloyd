using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LinkControllerScript : MonoBehaviour {

    public event System.Action GetT;

    public int health = 5;
    public float backForce = 10;
    public int trifor;

    public float timeToShoot = 0.7f;
    private float shootingTimer;

    Animator anim;//This creates a reference to the animator so it can access the variables 
	public LayerMask WhatIsGround;
	
	
	public float move = 0f;
	float groundRadius = 0.05f;
	float attackOnce = 0f;
	float attackTime = 0.2f;
	public float maxSpeed = 10f;
	public float jumpForce = 300f;
	//public float gravity = -9.8f;
	public static int flip = -1;

    /*Most of these are variables accessed by the Animator*/
    [HideInInspector] public bool grounded = false;
    [HideInInspector] public bool groundLine = false;
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool crouch = false;
    [HideInInspector] public bool attack = false;
    [HideInInspector] public bool movement = true;
    [HideInInspector] public bool dam = false;
    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool getTriforce = false;
   


    bool rising = false;

	
	public Transform groundCheck;
    public Collider2D lift;
    Rigidbody2D rb2d;
    

	/*These are needed so I can access the colliders. 
	 Link has a shield that I have set as a trigger for reasons I will explain later.*/
	public GameObject Link;
	public GameObject Shield;
	public GameObject Sword;
    public GameObject blade;

    [HideInInspector] public BoxCollider2D linkBox;
    [HideInInspector] public BoxCollider2D shieldBox;
    [HideInInspector] public BoxCollider2D swordBox;

    /*Sounds*/
    private AudioSource audioSource;
    public AudioClip jumping;
    public AudioClip hit;
    public AudioClip sword;
    public AudioClip sword2;
    public AudioClip triforce;
    

    void Awake (){
		/*These initialize the Game Objects above when Link shows up on screen*/
		linkBox = Link.GetComponent<BoxCollider2D>();
		shieldBox = Shield.GetComponent<BoxCollider2D>();
		swordBox = Sword.GetComponent<BoxCollider2D>();

        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        trifor = 3;
        rb2d = GetComponent<Rigidbody2D>();



    }
	
	void FixedUpdate () 
	{
        if (rb2d.IsTouching(lift))
        {
            crouch = false;
        }

            /*This checks if Link is on the ground which is used by the jump and crouch animations*/
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGround);

		

		/*These are the variables the Animator accesses.*/
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs(move));
		anim.SetBool ("Crouch", crouch);
		
		anim.SetBool ("Attack", attack);
        anim.SetBool("Dam", dam);
        anim.SetBool("GetTriforce", getTriforce);


        crouch = Input.GetKey("down");
		//move = Input.GetAxis ("Horizontal");

		if((GetComponent<Rigidbody2D>().velocity.y)>0){
			rising = true;
		}//if
		else if ((GetComponent<Rigidbody2D>().velocity.y)<0){
			rising = false;
		}else{
			rising = false;
		}//else if

		if (movement == true) {
			move = Input.GetAxis ("Horizontal");
			GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}//if
		if (movement == false) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);
			move = 0;
		}//if

		/*CROUCHING*/
		if (!crouch) {
				//rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
				//I set the colliders back to the original positions
				linkBox.size = new Vector2(1.0f, 1.9f);
				shieldBox.offset = new Vector2(0.0f, 0.0f);
                linkBox.offset = new Vector2(0.0f, 0.0f);
				movement = true;
                //ShieldBoxRetract();
        }

		if(crouch){
			movement = false;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);
			move = 0;
            ColliderCrouch();
        }//f

		if (rising) {
            //I change the size of link's collider and shift the shield collider down
            //I also set the horizontal movement to 0.
            
            if (crouch && grounded && !attack){
				movement = false;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);
				move = 0;
			}else{
				movement = true;
				move = Input.GetAxis ("Horizontal");
			}//else if
		}
		/*CROUCHING*/


		
		if (move > 0 && !facingRight)
						Flip();
		else if (move < 0 && facingRight)
						Flip();       

        
    }//FixedUpdate

	// Update is called once per frame
	void Update()
	{
        trifor = (int)StaticValue.value;
        print("trifor" + trifor);

        if (grounded && Input.GetButtonDown("Jump")) 
		{
			anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D>().AddForce( new Vector2(0.0f, jumpForce));
            jump = true;

            audioSource.clip = jumping;

            audioSource.Play();
        }
        else
        {
            jump = false;
        }

       
        /*I am in a similar boat with this. It will neeed to be changed but I'm too busy
		 getting the animations not to suck. These last two ifs are for the attack btw*/

        

        if (Input.GetKeyDown(KeyCode.F) && !crouch)
        {
            
            attack = true;           

            attackOnce = Time.time;
            if (health == 5) StartCoroutine(Wait());
            SwordBoxAttack();
            audioSource.clip = sword;
            audioSource.Play();
        }			
      
       
        if (attack == true) {
			if (grounded)
				movement = false;
			if(!grounded){
				movement = true;
			}//if
            
        }//if
        


        if ((Time.time - attackOnce) >= attackTime) {
            
            attack = false;
            SwordBoxRetract();
            movement = true;
		}//if

        if (getTriforce == true && (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.F)))
        {
            StaticValue.value--;

            getTriforce = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

    }//Update
	

	//Changes the scale on the screen to turn the other direction
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		flip *= -1;
	}//Flip

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
		/*linkBox.size = new Vector2(0.9f, 1.7f);
		linkBox.offset = new Vector2(0.0f, -0.15f);
		shieldBox.offset = new Vector2(0.55f, -0.24f);*/

        linkBox.size = new Vector2(1.0f, 1.7f);
        linkBox.offset = new Vector2(0.0f, -0.12f);
        shieldBox.offset = new Vector2(0.2f, -0.23f);
    }//Jumping shield  animation

    private void OnTriggerEnter2D(Collider2D collision)
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

        
        /*
        if (collision.gameObject.tag == "Enemy")
        {           
          
            Hit((transform.position - collision.transform.position).normalized);           

        }
        */
        

        if (collision.gameObject.name == "lava")
        {
            health = 0;
        }

        if (collision.gameObject.tag == "Triforce")
        {           
            Destroy(collision.gameObject);
            audioSource.clip = triforce;
            audioSource.Play();
            getTriforce = true;
            

            //collision.transform.position = new Vector2(transform.position.x, transform.position.y + 1.5f);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            
        }

        if (collision.gameObject.name == "Lift")
        {
            anim.SetFloat("vSpeed", 0f);
        }

    }
    
    float curTime = 0;
    float nextDamage = 2;  

    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Enemy")
        
            if (curTime <= 0 && collision.gameObject.tag == "Enemy")
            {
                Hit((transform.position -collision.transform.position).normalized);

                curTime = nextDamage;
            
            }
            else
            {

                curTime -= Time.deltaTime;
            }
        
    }

    public void Hit(Vector3 direction)
    {
        anim.SetBool("Dam", true);
        Vector2 backDirection = (direction).normalized;
        //print(backDirection);
        GetComponent<Rigidbody2D>().AddForce(backDirection * backForce);
        //rb2d.AddForce(new Vector2(direction.x * -600, direction.y * backForce));
        // backTimer = 1f;
        
            health--;
        //hitting = false;
       

        audioSource.clip = hit;
        audioSource.Play();
    }
   

   
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject b;
        audioSource.clip = sword2;
        audioSource.Play();
        
        if (facingRight)
        {
            
            blade.GetComponent<SpriteRenderer>().flipX = true;
            b = Instantiate(blade, transform.position + new Vector3(1.2f, 0.0f, 0f), Quaternion.identity);
            b.GetComponent<Rigidbody2D>().AddForce(new Vector3(1f, 0f, 0f) * 500);
            //Destroy(b, 3);

        }
        else
        {
            print("left");
            blade.GetComponent<SpriteRenderer>().flipX = false;
            b = Instantiate(blade, transform.position - new Vector3(1.2f, 0.0f, 0f), Quaternion.identity);
            b.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1f, 0f, 0f) * 500);
            //Destroy(b, 3);
        }
        /*
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0)
        {
            shootingTimer = timeToShoot;
            GameObject b = Instantiate(blade, transform.position - new Vector3(1.3f, -0.3f, 0f), Quaternion.identity);
             b.GetComponent<Rigidbody2D>().AddForce(new Vector3(1f, 0f, 0f) * 500);
            Destroy(b, 3);

        }*/
    }
}