using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeScrip : MonoBehaviour{

    private void OnCollisionEnter2D(Collision2D collision)    
    {
        if (collision.collider.gameObject.layer != LayerMask.NameToLayer("Player")) { 
            Destroy(gameObject);
        }
       
    }
}
