using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 10;
    public float lifetime = 1;
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            GameObject exp = (GameObject)(Instantiate(explosion, transform.position, Quaternion.identity));
            Destroy(exp, 1f);
            Destroy(gameObject);
        }

    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject exp = (GameObject)(Instantiate(explosion, transform.position, Quaternion.identity));
            Destroy(gameObject);
        }
    }

    
}
