using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour
{

    private Rigidbody2D rb2d;
    float move = 0f;
    public float maxSpeed = 3f;
  
    public Camera cameraUp;
    public Camera cameraDown;   
    
    private LinkController link;


    //public Camera cameraDown;

    private void Awake()
    {
        cameraUp.enabled = true;
        cameraDown.enabled = false;
        
    }
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        link = FindObjectOfType<LinkController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (rb2d.IsTouching(link.linkBox))
        {
            move = Input.GetAxis("Vertical");            
            rb2d.velocity = new Vector2(0, move) * maxSpeed;
          
        }
     
    }  


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.name == "CameraSwap")
        {
            if (Input.GetKey("down"))
            {

                cameraUp.enabled = false;
                cameraDown.enabled = true;

            }
            if (Input.GetKey("up"))
            {
                cameraUp.enabled = true;
                cameraDown.enabled = false;
            }

        }  
       

    }
}