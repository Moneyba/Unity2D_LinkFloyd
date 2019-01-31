using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriforce : MonoBehaviour {

    public GameObject triforce;
        
	
	// Update is called once per frame
	void Update () {
        
        if (GManager.tenisWin)
        {          
            
            triforce.SetActive(true);
        }
        
	}
}
