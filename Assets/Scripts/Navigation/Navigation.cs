using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    private bool door1 = false;
    // Update is called once per frame
    void Update()
    {
        if (door1 == true  && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("Tenis");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Borders"))
        {
            SceneManager.LoadScene("OverWorld");

        }

        if (collision.gameObject.CompareTag("Zelda"))
        {
            SceneManager.LoadScene("ZeldaRoom");
        }


        if (collision.gameObject.CompareTag("Town"))
        {
            SceneManager.LoadScene("Town");
        }

        if (collision.gameObject.CompareTag("Temple"))
        {
            SceneManager.LoadScene("Temple");
        }




    }
    
    public void manageCollisions(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // SceneManager.LoadScene("Tenis");
        }
          

    }

    /*public void manageCollisions(ControllerColliderHit hit)
    {
        print("Collided with " + hit.collider.gameObject.name);
        string tagOfTheOtherObject = hit.collider.gameObject.tag;
        if (hit.collider.gameObject.tag == "Player")
        {
            print("event");
        }


    }

    public void col (bool collision)
    {
        if(collision == true)
        {
            SceneManager.LoadScene("Tenis");
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Door1"))
        {
            door1 = true;     

        }

    }
}
