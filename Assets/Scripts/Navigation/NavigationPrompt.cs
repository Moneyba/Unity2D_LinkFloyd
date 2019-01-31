using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NavigationPrompt : MonoBehaviour {

public Vector3 startingPosition;

  void OnCollisionEnter2D(Collision2D collision){
    if (collision.gameObject.CompareTag("Player"))
        {
      
            GameState.SetLastScenePosition(SceneManager.GetActiveScene().name, startingPosition);
        }
	
  }

       
}