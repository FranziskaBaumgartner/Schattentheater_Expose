using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//based on a tutorial by Brackeys on Youtube https://www.youtube.com/watch?v=JivuXdrIHK0

public class PauseMenu : MonoBehaviour
{
   public static bool GameIsPaused = false;
   public GameObject PauseMenuUI;
   public GameObject teacher;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        teacher.GetComponent<AudioSource>().UnPause(); 
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        teacher.GetComponent<AudioSource>().Pause(); 
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game..");
        Application.Quit();
    }
}
