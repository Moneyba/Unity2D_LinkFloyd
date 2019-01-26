using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour
{

    
    private LineRenderer laser;
    int shootableMask;                     // A layer mask so the raycast only hits things on the shootable layer.
    private float range = 500f;                      // The distance the gun can fire.

    private float timer = 0f;
    private float timeBetweenShoots = 2f;
    private float shootEffect = 0.05f;

    private AudioSource laserSound;

    private Light resplandor;

    public float timeToShoot = 1f;
    private float shootingTimer;


    // Use this for initialization
    void Start()
    {
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask("Player");
        
        laser = GetComponent<LineRenderer>();
        laser.enabled = false;

        laserSound = GetComponent<AudioSource>();

        resplandor = GetComponentInChildren<Light>();

        shootingTimer = timeToShoot;


    }

    // Update is called once per frame
    void Update()
    {

        /*shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0)
        {
            shootingTimer = timeToShoot;
            Shoot();
        }*/
        //float movY = Input.GetAxis("Vertical");
        timer += Time.deltaTime;
       
        if (timer >= timeBetweenShoots)
        {

            Shoot();
        }

        if (timer >= shootEffect && laser.enabled == true)
        {

            DisableShoot();
        }
        /*
        if (movY > 0f)
        {
            //ship.AddForce(new Vector3(0f, 10f, 0f));
            transform.position += new Vector3(0f, 0.05f, 0f);

        }
        else if (movY < 0f)
        {
            //ship.AddForce(new Vector3(0f, -10f, 0f));
            transform.position += new Vector3(0f, -0.05f, 0f);
        }*/
    }

    void Shoot()
    {

        laser.SetPosition(0, transform.position);

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootableMask);
        if (hit.collider != null)
        {
            print("shoot");
            laser.SetPosition(1, hit.point);
           // GetComponent<LinkController>().Hit(transform.position - hit.transform.position);
            //Destroy(hit.collider.gameObject);
        }
        else
        {
            laser.SetPosition(1, transform.position + Vector3.forward * range);
        }

        laser.enabled = true;
        resplandor.enabled = true;
        laserSound.Play();
        timer = 0f;
    }

    void DisableShoot()
    {
        timer = 0f;
        laser.enabled = false;
        resplandor.enabled = false;
    }
}






