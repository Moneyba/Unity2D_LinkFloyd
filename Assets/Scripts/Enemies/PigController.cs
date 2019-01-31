using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigController : MonoBehaviour {

    private Animator animation;
    private bool dam = false;

    // Use this for initialization
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        animation.SetBool("Dam", dam);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Sword")
        {
            animation.SetBool("Dam", true);

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            animation.SetBool("Dam", true);
          
        }
    }
}
