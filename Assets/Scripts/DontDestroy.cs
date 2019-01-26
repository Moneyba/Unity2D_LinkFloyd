using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DontDestroy : MonoBehaviour
{
    string newSceneName;
    public static DontDestroy instance;
    public GameObject canvas;


    int cont = 0;

    void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            

            
            /*
            for (int i = 0; i < 3; i++)
            {
                triforcePanel[i].SetActive(false);
            }*/
            /*
                GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);*/
        }

    }
    private void Update()
    {        
        if (SceneManager.GetActiveScene().name == "tenis")
        {
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
        }

    }




}
