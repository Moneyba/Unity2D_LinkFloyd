using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : EnemiesStats {
    [HideInInspector] public bool facingRight = true;
    public static int flip = -1;
    public Transform target;
    private Animator animator;
    public float moveSpeed = 1f;
    public float rotationSpeed = 5;
  

    public Transform lineStart, lineEnd;

    private bool attack = false;

    private float move;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
  
       
    }
	
	// Update is called once per frame
	void Update () {

        animator.SetBool("attack", attack);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

        move = target.transform.position.x - transform.position.x;
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();       

       
        animator.SetFloat("speed", Mathf.Abs(transform.position.x));

        if (Physics2D.Linecast(lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer("Player")))
        {            
            attack = true;
        }
        else
        {
            attack = false;
        }
        
    }

 

    //Sends a ray out in front of link to detect foreground objects
    void Raycasting()
    {
        if (Physics2D.Linecast(lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer("Player")))
        {
            
            attack = true;
        }
        else
        {
            attack = false;
        }
    }//Raycasting

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        flip *= -1;
    }
}
