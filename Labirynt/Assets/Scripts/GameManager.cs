using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int timeToEnd;
    bool endGame = false;
    bool gamePaused = false;
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        if (timeToEnd <= 0)
        {
            timeToEnd = 30;
        }
        InvokeRepeating("Stopper", 2, 1);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
           if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        Debug.Log("End time");

    }
    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time to end: " + timeToEnd + " s");
        if ( timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame)
        {
            EndGame();
        }
    }

    void PauseGame()
    {
        Debug.Log("Pause game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    void ResumeGame()
    {
        Debug.Log("Resume game");
        Time.timeScale = 1f;
        gamePaused = false;
    }
}
