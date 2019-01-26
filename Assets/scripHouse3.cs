using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripHouse3 : MonoBehaviour
{
    static CheckGameOver check;
    public GameObject triforce;
    // Use this for initialization
    void Start () {

        check = new CheckGameOver();
       

    }
	
	// Update is called once per frame
	void Update () {
		if (check.win == true)
        {
            triforce.SetActive(true);
        }
	}
}
