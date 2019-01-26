using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {

    
    public GameObject bulletPrefab;
    public float timeToShoot = 1f;
    private float shootingTimer;

    //private AudioSource pigAudio;

	// Use this for initialization
	void Start () {
        shootingTimer = timeToShoot;
       
       
        //pigAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
       

        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0)
        {
            shootingTimer = timeToShoot;
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = transform.position + transform.forward;
            bulletObject.transform.forward = transform.forward;
        }

        

        //detectPlayer();

    }
    /*
        void detectPlayer()
        {
            float playerXPosition = GameObject.Find("Link").transform.position.x;
            if (transform.position.x < (playerXPosition + 1) && transform.position.x > (playerXPosition + -1)) Shoot();
        }*/
   

}
