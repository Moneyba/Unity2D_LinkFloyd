using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DontDestroy : MonoBehaviour
{
    string newSceneName;
    public static DontDestroy instance;
    public GameObject canvas;


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
