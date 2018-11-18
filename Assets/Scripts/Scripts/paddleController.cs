//using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;


public class paddleController : MonoBehaviour {

  

    private float paddleSpeed = 0.2f;
    private string axisControl;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        axisControl = "Horizontal";
        
        float xPos = transform.position.x + (Input.GetAxisRaw(axisControl) * paddleSpeed);
        transform.position = new Vector3(Mathf.Clamp(xPos, -5f, 5f), -5f, 0f);

    }
}
    