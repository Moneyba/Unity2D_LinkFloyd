using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//Destroy (gameObject, 10);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
			//Destroy (coll.gameObject);
			collision.gameObject.GetComponent<LinkController>().Hit((transform.position - collision.transform.position).normalized);
            //GameObject.Find ("Link").GetComponent<ManagePlayerHealth> ().increaseScore ();
            Destroy (gameObject);
		}
        Destroy(gameObject);
    }

}
