using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)//If game already paused.
            {
                ResumeGame();
            }
            else //Game is not already pasued.
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        //To-Do
        Debug.Log("Loading main menu...");
    }

    public void SaveGame()
    {
        Debug.Log("Saving game...");
        GameManager.SaveGame();
    }

    public void LoadGame()
    {
        Debug.Log("Loading game...");
        GameManager.LoadGame();
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();

    }
}
