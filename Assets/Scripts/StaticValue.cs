using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StaticValue : MonoBehaviour {

    public static float value = 3;
    public static bool tenisWin = false;

    LinkControllerScript link;
	// Use this for initialization
	void Start () {
		
    }
	
	// Update is called once per frame
	void Update () {
      //  value += (Time.deltaTime * 1.5f);

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(value);
            Debug.Log(tenisWin);
        }


	}
}
