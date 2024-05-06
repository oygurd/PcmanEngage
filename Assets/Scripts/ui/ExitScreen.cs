using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScreen : MonoBehaviour
{
    public GameObject exitScreenUI;

    //Opens the screen by pressing the escape button
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowExitScreen();
        }
    }

    // Call this function to show the exit screen
    public void ShowExitScreen()
    {
        exitScreenUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    // Call this function to hide the exit screen
    public void HideExitScreen()
    {
        exitScreenUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    // Call this function to restart the current level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Resume the game
    }

    // Call this function to restart the current level
    public void GoToMainManu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f; // Resume the game
    }
    
    // Call this function to exit the game
    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }
}
