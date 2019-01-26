using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    private bool door1 = false;
    private bool door3 = false;
    // Update is called once per frame
    void Update()
    {
        if (door1 == true && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("House1");
        }
        
        if (door3 == true  && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("House3");
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
            SceneManager.LoadScene("GreatPalace");
        }

        if (collision.gameObject.CompareTag("HouseExit"))
        {
            SceneManager.LoadScene("Town");
        }

        if (collision.gameObject.name == "TennisDoor")
        {
            SceneManager.LoadScene("Tenis");
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
        if (collision.gameObject.name == "Door1")
        {

            door1 = true;
            door3 = false;

        }


        if (collision.gameObject.name == "Door3")
        {
           
            door3 = true;
            door1 = false;

        }

    }
}
