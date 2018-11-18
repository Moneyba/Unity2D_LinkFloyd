using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour {

    private Rigidbody2D rb2D;
    public float vel = 600f;
    private bool ballInPlay;

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();

        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb2D.isKinematic = false;
            rb2D.AddForce(new Vector3(vel, vel, 0f));
        }
		
	}
}
