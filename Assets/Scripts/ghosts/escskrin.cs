using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escskrin : MonoBehaviour
{
    [SerializeField] GameObject exitScren, gameScren;
    // Start is called before the first frame update
    void Start()
    {
        exitScren.SetActive(true);
        gameScren.SetActive(false);
        Time.timeScale = 0;
        pause = false;
    }
    private bool pause;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseFunkshen();
        }

    }

/*    public void qwit()
    {
        Application.Quit();
    }*/

    public void pauseFunkshen()
    {
        if (pause)
        {
            Time.timeScale = 1;
            exitScren.SetActive(false);
            gameScren.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            exitScren.SetActive(true);
            gameScren.SetActive(false);
        }
        pause = !pause;
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
