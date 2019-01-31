using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{

    public int lives = 3;
    public int rupees = 0;
    public float resetDelay = 1f;
    public Text livesText;    
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject rupee;
    public GameObject paddle;
    public GameObject deathParticles;
    public static GM instance = null;
   

    private GameObject clonePaddle;

    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);     

        Setup();       
       
    }

   

    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(rupee, new Vector3(-20,15,0), Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (rupees > 15)
        {
            GManager.tenisWin = true;
            
            youWon.SetActive(true);
            SceneManager.LoadScene("House3");
        }

        if (lives < 1)
        {
            GManager.tenisWin = false;
            
            gameOver.SetActive(true);
            SceneManager.LoadScene("House3");
        }

    }

    void Reset()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);


    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "L:" + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyRupee()
    {
        rupees++;        
        CheckGameOver();       
    }

    
}