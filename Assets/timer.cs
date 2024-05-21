using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // גרור ושחרר את אובייקט ה-TextMeshPro כאן דרך ה-Inspector
    private float elapsedTime;

    void Start()
    {
        elapsedTime = 0f;  // התחלת הזמן באפס
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        DisplayTime(elapsedTime);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}


//timer