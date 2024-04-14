using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class endScrean : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textCurrentScore, textHighestScore;
    [SerializeField] GameObject endScreenUI;
    [SerializeField] manager maneger;

    private float currentScore;
    private float highestScore;

    // Call this function to show the exit screen
    public void ShowEndScreen()
    {
        currentScore = maneger.points;
        UpdateScore();
        GetHighestScore();
        textHighestScore.text = highestScore.ToString();
        textCurrentScore.text = currentScore.ToString();
        endScreenUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
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
        Application.Quit();
    }


    // This function should be called whenever the player's score is updated
    public void UpdateScore()
    {
        if (currentScore > highestScore)
        {
            highestScore = currentScore;
            PlayerPrefs.SetFloat("HighestScore", highestScore);
            PlayerPrefs.Save();
        }
    }

    // This function can be called to retrieve the highest score
    public float GetHighestScore()
    {
        highestScore = PlayerPrefs.GetFloat("HighestScore", 0);
        return highestScore;
    }
}
