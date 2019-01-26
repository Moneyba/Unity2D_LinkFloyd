using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationM : MonoBehaviour {

    private bool messageGirl1;
    private float timer;
   // public Canvas canvas;
    public GameObject dialogBox;
    public Text textHolder;

    // Use this for initialization
    void Start () {
        
        //dialogBox = GameObject.Find("DialogBox").GetComponent<Image>();
       
        //textHolder = GameObject.Find("DialogText").GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        //dialogBox.enabled = false;
        //messageGirl1 = false;
        print("mesagge: "+messageGirl1);
     
        if (messageGirl1 == true)
        {
            
            timer += Time.deltaTime;
            if (timer <= 2.0)
            {
                dialogBox.SetActive(true);
                
                textHolder.text = "Would you like to play? ;)";
               
            }
            else
            {
                textHolder.text = "";
                messageGirl1 = false;
                dialogBox.SetActive(false);
                timer = 0f;
            }

        }
        /*
        if (messageGirl1 == true)
        {
            dialogBox.enabled = true;

            textHolder.text = "Would you like to play?";
        }
        else
        {
            textHolder.text = "";
            messageGirl1 = false;
            
        }*/

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            messageGirl1 = true;
        }
      
    }
    
}
