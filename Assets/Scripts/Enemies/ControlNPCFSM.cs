using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNPCFSM : MonoBehaviour {
    private Animator anim;
    private Ray ray;
    private RaycastHit hit;
    private AnimatorStateInfo info;
    private string objectInsight;

    public Transform target;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
     
        ray.origin = transform.position;
        ray.direction = transform.forward;
        info = anim.GetCurrentAnimatorStateInfo(0);
        objectInsight = "";
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if(Physics.Raycast(ray.origin, ray.direction * 100, out hit))
        {
            objectInsight = hit.collider.gameObject.tag;
            print("Object in Sight" + objectInsight);
            if(objectInsight == "Player")
            {
                anim.SetBool("canSeePlayer", true);
                print("Just saw the Player");
            }
        }
        if (info.IsName("Idle")){
            print("We are in the Idle state");
        }
        else if (info.IsName("Follow_Player"))
        {
            transform.right = target.position - transform.position;
        }
        if (objectInsight != "Player")
        {
            anim.SetBool("canSeePlayer", false);
            print("Just lost sight of the player");
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        print("We are in the follow_player state");
	}


}

