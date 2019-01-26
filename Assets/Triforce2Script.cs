using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triforce2Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Triforce");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
