using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameOver : GM
{
    public GM GM;
    public bool win;
    
	// Use this for initialization
	void Start () {            

        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if (GM.rupees > 15)
        {
            win = true;
        }
        
        
    }
   
}
