using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameM : MonoBehaviour {

    public LinkController link;
    public GameObject[] hearts;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(link.health);
        if(link != null)
        {
            for(int i = 0; i<hearts.Length; i++)
            {
                hearts[i].SetActive(i<link.health);
            }
        }
        else
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].SetActive(false);
            }
        }
	}
}
