using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject Enemy;
    float SpawnRate = 5f;
    public GameObject controls;
    public GameObject GameOverScreen;
    public GameObject WinScreen;
    public Text timer;
    float counter = 1f;
    int CleanCount = 50;
    public float time;
    bool gameRunning;
    void Start()
    {
     Destroy(controls.gameObject, 5f);
    }

    void Update()
    {

        if(CleanCount == 0)
        {
            Win();
        }

         if(Input.GetKeyDown(KeyCode.R))
      {
        Time.timeScale = 1f;    
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
      }        

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }


      if(gameRunning && counter > 0f)
      {
        counter -= Time.deltaTime;
        if(counter <= 0f)
        {
          counter = 1f;
          CleanCount -= 1;
        }
      }
      timer.text = CleanCount.ToString();
    
      time += Time.deltaTime;
      SpawnRate -= Time.deltaTime;

      if(SpawnRate <= 0)
      {
      int randomSpawn = Random.Range(0, spawnPoint.Length);
      Instantiate(Enemy, spawnPoint[randomSpawn].position, spawnPoint[randomSpawn].rotation);   
      if(time < 5f)
      {
       
      }

      if(time > 5f && time < 15f)
      {
      gameRunning = true;
      SpawnRate = 3f; 
      }

      if(time > 15f && time < 20f && gameRunning == true)
      {
      SpawnRate = 2f; 
      }
      
      if(time > 20f && time < 35f && gameRunning == true)
      {
      SpawnRate = 1.5f; 
      }

      if(time > 35f && time < 45f && gameRunning == true)
      {
      SpawnRate = 1f; 
      }

      if(time > 45f && gameRunning == true)
      {
      SpawnRate = 0.5f; 
      }

      if(gameRunning == false)
      {
      SpawnRate = 300f; 
      }
      }
    }

    public void GameOver()
    {
     GameOverScreen.SetActive(true);
     gameRunning = false;
    }

    void Win()
    {
      WinScreen.SetActive(true);
      gameRunning = false;
      Time.timeScale = 0f; 
    }
}
