using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // Use this for initialization
    public Transform hero;
    public float leftLimit ;
    public float rightLimit;
    
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(Mathf.Clamp(hero.position.x, leftLimit, rightLimit), transform.position.y, transform.position.z);
    }


}
