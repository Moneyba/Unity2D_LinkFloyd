using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : EnemiesStats {

    public Vector2[] directions;
    public float timeToChange = 1;
    public float movementSpeed;

    private int directionPointer;
    private float directionTimer;

    // Use this for initialization
    void Start() {
        directionPointer = 0;
        directionTimer = timeToChange;

    }

    // Update is called once per frame
    void Update() {


        // Changing the direction
        directionTimer -= Time.deltaTime;
        if (directionTimer <= 0)
        {
            directionTimer = timeToChange;
            directionPointer++;
            if (directionPointer >= directions.Length)
            {
                directionPointer = 0;
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            { GetComponent<SpriteRenderer>().flipX = false; }

        }
        //Make the object move.
        GetComponent<Rigidbody2D>().velocity = new Vector2(directions[directionPointer].x * movementSpeed, directions[directionPointer].y * movementSpeed);


    }

  
}



    


