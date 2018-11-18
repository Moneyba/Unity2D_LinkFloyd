using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour {

    public string levelToLoad = "Zelda";

    public void LoadTheLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
