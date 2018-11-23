using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health = 1;
	
    public virtual void Hit() {
        health--;
        if( health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (other.GetComponent<Sword>() != null)
        if (collision.gameObject.CompareTag("Sword"))
        {
            Hit();
        }
        /*else if (collision.gameObject.CompareTag("arrow"))
        {
            Hit();
            Destroy(collision.gameObject);
        }*/
    }
    
}
