﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LinkController))]
public class LinkAnimator : MonoBehaviour
{

    public float timeToShoot = 0.7f;

    private Animator anim;

    public static int flip = -1;

    
    [HideInInspector] public bool groundLine = false;
    [HideInInspector] public bool crouch = false;
    [HideInInspector] public bool movement = true;
    [HideInInspector] public bool dam = false;

    [HideInInspector] public bool getTriforce = false;

   

   

    void Awake()
    {
        anim = GetComponent<Animator>();
        //link = GetComponent<LinkController>();

    }

    private void Update()
    {

        anim.SetBool("Ground", LinkController.instance.grounded);
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(LinkController.instance.move));
        anim.SetBool("Crouch", LinkController.instance.crouch);
        anim.SetBool("Attack", LinkController.instance.attack);
        anim.SetBool("Dam", dam);
        anim.SetBool("GetTriforce", getTriforce);

        crouch = Input.GetKey("down");

        if (LinkController.instance.move > 0 && !LinkController.instance.facingRight)
            Flip();
        else if (LinkController.instance.move < 0 && LinkController.instance.facingRight)
            Flip();



        if (getTriforce == true && (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.F)))
        {
            GManager.value--;
            getTriforce = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
        }
    }

    //Changes the scale on the screen to turn the other direction
    void Flip()
    {
        LinkController.instance.facingRight = !LinkController.instance.facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        flip *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Triforce")
        {
            AudioManager.instance.PlaySound("Triforce", transform.position);
            getTriforce = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }

        if (collision.gameObject.GetComponent<EnemyBullet>() != null && crouch == false)
        {
            dam = true;
        }
        else
        {
            dam = false;
        }
    }

  
  /* private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.GetComponent<CharacterStats>() != null || collision.gameObject.GetComponent<EnemyBullet>() != null) && crouch == false)
        {
            dam = true;
        }
        else
        {
            dam = false;
        }       
        
        
    }*/


    public void triggerDamage(float damageTime)
    {
        StartCoroutine(Damage(damageTime));
    }

    IEnumerator Damage(float damageTime)
    {
        //Ignore collision with Enemies
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);
        LinkController.instance.linkBox.enabled = false;
        LinkController.instance.linkBox.enabled = true;

        //Start damage anim
        dam = true;
        //Wait for damage to end
        yield return new WaitForSeconds(damageTime);

        //Stop damage anim and re-enable collision
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
        dam = false;
    }

   


}

    
       
