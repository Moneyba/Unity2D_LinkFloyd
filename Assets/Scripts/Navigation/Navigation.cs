using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
   


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Borders"))
        {
            AudioManager.instance.PlayMusic(null);
            SceneManager.LoadScene("OverWorld");

        }

        if (collision.gameObject.CompareTag("Zelda"))
        {
            SceneManager.LoadScene("ZeldaRoom");
        }


        if (collision.gameObject.CompareTag("Town") && GManager.value == 2)
        {
            SceneManager.LoadScene("Town");
        }

        if (collision.gameObject.CompareTag("Temple") && GManager.value == 1)
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

  
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Door1" && Input.GetButtonDown("Fire1"))
        {

            SceneManager.LoadScene("House1");

        }

        if (collision.gameObject.name == "Door2" && Input.GetButtonDown("Fire1"))
        {

            SceneManager.LoadScene("House2");

        }


        if (collision.gameObject.name == "Door3" && Input.GetButtonDown("Fire1"))
        {

            SceneManager.LoadScene("House3");

        }
       
    }
}
