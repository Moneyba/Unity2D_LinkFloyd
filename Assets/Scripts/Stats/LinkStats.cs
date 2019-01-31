using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LinkStats : CharacterStats
{
   
    public LinkController linkController;
    

    public void Start()
    {
        linkController = GetComponent<LinkController>();
    }


    public override void Die()
    {


        base.Die();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.GetComponent<CharacterStats>() != null || collision.gameObject.GetComponent<EnemyBullet>() != null) && linkController.crouch == false)
        {
            Hit((transform.position - collision.transform.position).normalized);
            AudioManager.instance.PlaySound("Link_Hit", transform.position);

        }

        if (collision.gameObject.name == "lava")
        {
           
            Die();
        }

    }

    float curTime = 0;
    float nextDamage = 2;

    private void OnCollisionStay2D(Collision2D collision)
    {        

        if (curTime <= 0 && collision.gameObject.tag == "CharacterStats" && linkController.crouch == false)
        {
            Hit((transform.position - collision.transform.position).normalized);
            AudioManager.instance.PlaySound("Link_Hit", transform.position);

            curTime = nextDamage;

        }
        else
        {

            curTime -= Time.deltaTime;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterStats>() != null && linkController.crouch == false)
        {
            Hit((transform.position - collision.transform.position).normalized);
            AudioManager.instance.PlaySound("Link_Hit", transform.position);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (curTime <= 0 && collision.gameObject.tag == "CharacterStats" && linkController.crouch == false)
        {
            Hit((transform.position - collision.transform.position).normalized);
            AudioManager.instance.PlaySound("Link_Hit", transform.position);

            curTime = nextDamage;

        }
        else
        {

            curTime -= Time.deltaTime;
        }
    }

}
