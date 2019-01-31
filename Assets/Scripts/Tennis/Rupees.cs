using UnityEngine;
using System.Collections;

public class Rupees : MonoBehaviour
{  

    public GameObject rupeeParticle;
    private AudioSource audioSource;

    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
    }

        void OnTriggerEnter2D(Collider2D other)
    {       
        Instantiate(rupeeParticle, transform.position, Quaternion.identity);
        GM.instance.DestroyRupee();        
        Destroy(gameObject);
    }
}