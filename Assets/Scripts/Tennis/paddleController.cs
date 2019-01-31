//using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;


public class paddleController : MonoBehaviour {

  

    private float paddleSpeed = 1f;
    private string axisControl;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        axisControl = "Horizontal";
        
        float xPos = transform.position.x + (Input.GetAxisRaw(axisControl) * paddleSpeed);
        transform.position = new Vector3(Mathf.Clamp(xPos, -30.5f, 30.5f), -25f, 0f);

    }
}
    