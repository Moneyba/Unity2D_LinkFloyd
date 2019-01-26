using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour {
    public GameObject projectile;
    public Transform target;
    float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.P))
        {
            time += Time.deltaTime;
            if(time >= 2.0)
            {
                time = 0;

                Vector3 diff = Camera.main.ScreenToWorldPoint(target.transform.position) - transform.position;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

                GameObject t = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
                t.GetComponent<Rigidbody2D>().AddForce(transform.forward * 1000);
                Destroy(t, 3);
            }

        }
	}
}
