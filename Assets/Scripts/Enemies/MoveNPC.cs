using UnityEngine;
using System.Collections;

public class MoveNPC : MonoBehaviour {
	public GameObject bullet;
	

	public bool startShootingTimer = false;
	public bool canShoot = true;
	public float shootingTimer;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (startShootingTimer) 
		{
			shootingTimer += Time.deltaTime;
			if (shootingTimer >= .5)
			{
				startShootingTimer = false;
				canShoot = true;
				shootingTimer = 0;
			}
		}
		
		detectPlayer ();

	
	}

	void detectPlayer()
	{
		float playerXPosition = GameObject.Find ("Link").transform.position.x;
		if (transform.position.x < (playerXPosition + 1) && transform.position.x > (playerXPosition + -1)) Shoot();
	}

	void Shoot()
	{

		if (canShoot) {
            GameObject bulletObject = Instantiate(bullet);
            bulletObject.transform.position = transform.position + transform.forward;
            bulletObject.transform.forward = transform.forward;

            canShoot = false;
			startShootingTimer = true;
		}

	}

}
