using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // Use this for initialization
    public Transform hero;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = hero.transform.position.x;
        transform.SetPositionAndRotation(new Vector3(x, transform.position.y, transform.position.z), Quaternion.identity);
	}
}
