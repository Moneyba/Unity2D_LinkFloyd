using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy {
    //private Rigidbody2D rb2D;
    //public float vel = 600f;
    //private float rand;

    // Use this for initialization
    void Start () {
        //rand = Random.Range(-0.02f, 0.02f);
        //rb2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
      //  transform.position += new Vector3(-0.05f, rand, 0f);
       // rb2D.AddForce(new Vector3(vel, vel, 0f));

    }
    
}
