using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameM : MonoBehaviour {

    public LinkControllerScript link;
    public GameObject link2;
    public GameObject[] hearts;    
    public GameObject T3;
    

    public Enemy darklink;
    public GameObject triforce3;

    public GameObject gameOver;
    public AudioClip gameOvr;

    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        //audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        
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

        if (link.getTriforce == true)
        {              
            T3.SetActive(true);    
                       
        }

        if (darklink.health <= 0)
        {
            triforce3.SetActive(true);
        }

        if(link.health <= 0)
        {
            
            gameOver.SetActive(true);
            link2.SetActive(false);
            audioSource.clip = gameOvr;
            audioSource.Play();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
                gameOver.SetActive(false);
            }
        }
	}
}
