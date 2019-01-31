using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesStats : CharacterStats {

    public AudioClip hit;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Hit((transform.position - collision.transform.position).normalized);

            AudioManager.instance.PlaySound(hit, transform.position);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Hit((transform.position - collision.transform.position).normalized);

            AudioManager.instance.PlaySound(hit, transform.position);

        }
    }

 

    public override void Die()
    {
        Destroy(gameObject);
        base.Die();
    }
}
