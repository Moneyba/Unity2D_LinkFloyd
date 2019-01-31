using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GManager : MonoBehaviour {
       
   
    public GameObject[] triforces;
    
    private Triforce destroyTriforce;

    public static GManager instance;
    private string sceneName;
    public static int value = 3;
    public static bool tenisWin = false;
  
    void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }

	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < triforces.Length; i++)
        {
            if (triforces[i] != null)
            {
                triforces[i].SetActive(i < value);
            }

        }

        if(value == 0)
        {
            Win();
        }

    }

   

    void Win()
    {
        AudioManager.instance.PlayMusic(null);
        SceneManager.LoadScene("StartScreen");
        Destroy(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        string newSceneName = SceneManager.GetActiveScene().name;
        if (newSceneName != sceneName)
        {            
            sceneName = newSceneName;
           
            destroyTriforce = FindObjectOfType<Triforce>();

            if (sceneName == "ZeldaRoom" && value <3)
            {
                Destroy(destroyTriforce.gameObject);
            }
            if (sceneName == "House3" && value < 2)
            {
                Destroy(destroyTriforce.gameObject);
            }


        }

    }
}
