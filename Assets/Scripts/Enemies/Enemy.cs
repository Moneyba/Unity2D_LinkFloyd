using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health = 1;
    
    public float backForce = 1;
       
    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public virtual void Hit(Vector3 direction) {
        Vector3 backDirection = (direction).normalized;
        print("backDirection=" + backDirection);
        GetComponent<Rigidbody2D>().AddForce(backDirection * backForce);
        health--;



        if ( health <= 0)
        {
            Destroy(gameObject);
        }
    }
    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (other.GetComponent<Sword>() != null)
        if (collision.gameObject.CompareTag("Sword"))
        {
            
            //audioClip.Play();
            Hit(transform.position - collision.transform.position);
        }
        /*else if (collision.gameObject.CompareTag("arrow"))
        {
            Hit();
            Destroy(collision.gameObject);
        }/
    }*/
    
}
