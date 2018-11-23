using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public Teleporter exitTeleporter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<LinkController>() != null)
        {
            if(exitTeleporter != null)
            {
                LinkController link = collision.GetComponent<LinkController>();
                //link.Teleport(link.transform.position = exitTeleporter.transform.position + exitTeleporter.transform.forward * 2f);
            }
        }
    }


}
