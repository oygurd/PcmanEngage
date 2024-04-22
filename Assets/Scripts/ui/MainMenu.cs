using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(int seaneNumber)
    {
        SceneManager.LoadScene(seaneNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


