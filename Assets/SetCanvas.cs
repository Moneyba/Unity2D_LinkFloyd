using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanvas : MonoBehaviour {

    public GameObject triforce;
    
    
	
	// Update is called once per frame
	void Update () {
        
        if (StaticValue.tenisWin)
        {          
            
            triforce.SetActive(true);
        }
	}
}
