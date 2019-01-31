using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempleManager : MonoBehaviour {
    public GameObject[] hearts;
    public AudioClip templeClip;
    public AudioClip startClip;

    public GameObject gameOver;
 
    private bool isGameOver;

    private LinkStats link;
    // Use this for initialization
    void Start () {
        link = FindObjectOfType<LinkStats>();
        FindObjectOfType<LinkStats>().OnDeath += OnGameOver;
    }
	
	// Update is called once per frame
	void Update () {

        if (link != null)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].SetActive(i < link.health);
            }

        }


        if (Input.GetKeyDown(KeyCode.Space) && isGameOver)
        {
            isGameOver = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("GreatPalace");
            gameOver.SetActive(false);
            AudioManager.instance.PlayMusic(templeClip);
            //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);

        }
    }

    void OnGameOver()
    {
        gameOver.SetActive(true);
        AudioManager.instance.PlaySound("Game_Over", transform.position);
        AudioManager.instance.PlayMusic(null);
        isGameOver = true;
        link.health = 5;
        //link.linkController.link.SetActive(false);
        Time.timeScale = 0f;

    }
   
}
