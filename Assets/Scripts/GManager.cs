using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GManager : MonoBehaviour {

    LinkControllerScript link;
    public GameObject linkGameObject;

    //public GameObject linkGameObject;
    public GameObject[] hearts;    
    //public GameObject T;   
   

    public GameObject[] triforces;

   // public Enemy pig;
   // public GameObject finalDoor;

    public GameObject gameOver;
    public AudioClip gameOvr;


    private AudioSource audioSource;

    public static GManager instance;

    

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

            link = FindObjectOfType<LinkControllerScript>();
            
        }
    }

    // Use this for initialization
    void Start () {
        
        audioSource = GetComponent<AudioSource>();       
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
       

        for (int i = 0; i < triforces.Length; i++)
        {
            triforces[i].SetActive(i < StaticValue.value);
            print(triforces[i] + " " + (i < StaticValue.value));
        }

        if (link.health <= 0)
        {

            gameOver.SetActive(true);

            
            linkGameObject.SetActive(false);
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
