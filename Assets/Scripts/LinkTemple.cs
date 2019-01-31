using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkTemple : MonoBehaviour {
    private bool key = false;
   
    public GameObject lava;
    public GameObject enemy;

    public AudioClip startTheme;
    public AudioClip pigSong;
    public AudioClip shineSong;
    /*private AudioSource audioSourceLink;
     
     public AudioClip _AudioClip1;
     public AudioClip _AudioClip2;
     public AudioClip keyAudio;
     public AudioClip doorAudio;*/

    public GameObject darkLink;
    public GameObject finalbattle;

    public GameObject pig;
    public GameObject finalDoor;

    public CameraController camera;
    public GameObject lim;
    bool pigActive = false;

    // Use this for initialization
    void Awake()
    {

        AudioManager.instance.PlayMusic(startTheme);


    }

    // Update is called once per frame
    public void Update()
    {
        if (pigActive == true && pig == null)
        {
            Destroy(finalDoor);
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "key")
        {
            key = true;
            Destroy(collision.gameObject);
            AudioManager.instance.PlaySound("Get_key", transform.position);

        }

        if (collision.gameObject.name == "door" && key == true)
        {

            Destroy(collision.gameObject);

            pigActive = true;
            pig.SetActive(true);
            AudioManager.instance.PlaySound("Door", transform.position); 
            AudioManager.instance.PlayMusic(pigSong);


        }

        if (collision.gameObject.name == "Gargoyle")
        {
            Destroy(lava);
            enemy.SetActive(true);
        }



        if (collision.gameObject.name == "FalseTriforce")
        {
            Destroy(collision.gameObject);
            AudioManager.instance.PlayMusic(shineSong);
            darkLink.SetActive(true);
            finalbattle.SetActive(true);

            //camera.enabled = true;
            camera.leftLimit = 36f;
            lim.SetActive(true);

        }


    }

}
