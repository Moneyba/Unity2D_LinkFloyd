using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy {

    
    public GameObject bulletPrefab;
    public float timeToShoot = 1f;
    private float shootingTimer;

	// Use this for initialization
	void Start () {
        shootingTimer = timeToShoot;
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
		
	}
}
