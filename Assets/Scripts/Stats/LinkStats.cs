using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LinkStats : CharacterStats
{
   

    public float damageTime = 3;

    public LinkAnimator anim;

    private void Start()
    {
        anim = GetComponent<LinkAnimator>();
    }

    public override void Die()
    {


        base.Die();
       
    }

   /* public override void Hit(Vector3 direction)
    {
        if (health < 0)
        {
            Die();
        }
        else
        {
            anim.triggerDamage(damageTime);
        }
        base.Hit(direction);
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.GetComponent<CharacterStats>() != null || collision.gameObject.GetComponent<EnemyBullet>() != null) && LinkController.instance.crouch == false)
        {

            Hit((transform.position - collision.transform.position).normalized);
            anim.triggerDamage(damageTime);

            AudioManager.instance.PlaySound("Link_Hit", transform.position);

        }

        if (collision.gameObject.name == "lava")
        {
           
            Die();
        }

    }

   /* float curTime = 0;
    float nextDamage = 5;

   /* private void OnCollisionStay2D(Collision2D collision)
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
        

    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterStats>() != null && LinkController.instance.crouch == false)
        {
            Hit((transform.position - collision.transform.position).normalized);
            AudioManager.instance.PlaySound("Link_Hit", transform.position);

        }
    }

   /*private void OnTriggerStay2D(Collider2D collision)
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

        //Start damage anim

        //Wait for damage to end
        yield return new WaitForSeconds(damageTime);

        //Stop damage anim and re-enable collision
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
    }

}
