﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float speed = 10;
    public float lifetime = 1;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
		
	}
}
