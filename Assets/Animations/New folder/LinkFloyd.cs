using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkFloyd : MonoBehaviour {

    private Rigidbody2D rb2d;

    private float horizontal;
    private float vertical;
    private Vector2 movement;

    public float speed = 4.0f;

    private Animator anim;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();
    }

  	
	// Update is called once per frame
	void Update () {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //movement = new Vector2(horizontal, vertical);
        //rb2d.velocity = movement * speed;

        if (vertical != 0)
        {
            rb2d.velocity = new Vector2(0, vertical) * speed;
            anim.SetBool("xMove", false);
            sprite.flipX = false;

            if (vertical > 0)
            {
                anim.SetInteger("yMove", 1);
            }
            else
            {
                anim.SetInteger("yMove", -1);
            }
            
        }
        else
        {
            rb2d.velocity = new Vector2(horizontal, 0) * speed;
            anim.SetInteger("yMove", 0);
            if (horizontal > 0)
            {
                anim.SetBool("xMove", true);
                sprite.flipX = false;
            }else if(horizontal < 0)
            {
                anim.SetBool("xMove", true);
                sprite.flipX = true;
            }
            else
            {
                anim.SetBool("xMove", false);
            }
        }

        if(vertical == 0 && horizontal == 0)
        {
            anim.SetBool("moving", false);

        }
        else
        {
            anim.SetBool("moving", true);

        }
	}
}
