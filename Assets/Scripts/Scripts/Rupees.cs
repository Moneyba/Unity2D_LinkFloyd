using UnityEngine;
using System.Collections;

public class Rupees : MonoBehaviour
{
    public AudioClip coin;

    public GameObject rupeeParticle;

    void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<AudioSource>().Play();
        Instantiate(rupeeParticle, transform.position, Quaternion.identity);
        GM.instance.DestroyRupee();        
        Destroy(gameObject);
    }
}