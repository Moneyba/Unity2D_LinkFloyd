 using UnityEngine;
 using System.Collections;
 public class DarkLinkController : MonoBehaviour
{
    public GameObject mirrorObject; // Object to mirror

    [HideInInspector] public bool facingRight = true;
    private Rigidbody2D rb2d;
    Animator anim;

    float move = 0f;
    public float maxSpeed = 3f;

    float vertical;
    float horizonal;
    Vector3 position;

    void Awake()
    {

       // rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

   
    void FixedUpdate()
    {
        print(transform.position);
        //move = -Input.GetAxis("Horizontal");
        //rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
        vertical = mirrorObject.transform.position.y;
        horizonal = -mirrorObject.transform.position.x;

        //transform.position = new Vector3(horizonal, vertical, 0);
        position = new Vector3(horizonal, vertical, 0);
        //transform.Translate(position);
       

        /* transform.position += new Vector3(-mirrorObject.transform.position.x, mirrorObject.transform.position.y, 0);
        ;*/
    }

   
}