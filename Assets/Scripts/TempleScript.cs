using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleScript : MonoBehaviour
{
    private bool key = false;
    public GameObject lava;
    public GameObject enemy;
    public AudioSource _AudioSource;
    private AudioSource audioSourceLink;

    public AudioClip _AudioClip1;
    public AudioClip _AudioClip2;
    public AudioClip keyAudio;
    public AudioClip doorAudio;

    public GameObject darkLink;
    public GameObject finalbattle;
    
    public GameObject pig;
    public GameObject finalDoor;

    public CameraController camera;
    public GameObject lim;
    bool pigActive = false;

    // Use this for initialization
    void Start()
    {
        audioSourceLink = GetComponent<AudioSource>();
        _AudioSource.clip = _AudioClip1;

        _AudioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (pigActive==true && pig == null)
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
            audioSourceLink.clip = keyAudio;

            audioSourceLink.Play();

        }
        
        if (collision.gameObject.name == "door" && key == true)
        {
           
            Destroy(collision.gameObject);
            
            pigActive = true;
            pig.SetActive(true);

            audioSourceLink.clip = doorAudio;

            audioSourceLink.Play();
            _AudioSource.clip = _AudioClip2;
            _AudioSource.Play();

            

        }

        if (collision.gameObject.name == "Gargoyle")
        {
            Destroy(lava);
            enemy.SetActive(true);
        }

       

        if (collision.gameObject.name == "Triforce")
        {
            Destroy(collision.gameObject);
            //Instantiate(darkLink, transform.position + new Vector3(2f, 0f, 0f), Quaternion.identity);
            darkLink.SetActive(true);
            finalbattle.SetActive(true);

            //camera.enabled = true;
            camera.leftLimit = 36f;
            lim.SetActive(true);

        }


    }
}
