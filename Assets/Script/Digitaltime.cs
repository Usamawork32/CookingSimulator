
using UnityEngine;
using UnityEngine.UI;

public class Digitaltime : MonoBehaviour
{
    public int minutes = 8;
    public int seconds = 0;

    public Text timerText;

    private float currentTime;

    void Start()
    {
        // Convert initial minutes and seconds to total seconds
        currentTime = minutes * 60 + seconds;
    }

    void Update()
    {
        // Update the timer
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            // Calculate remaining minutes and seconds
            int remainingMinutes = Mathf.FloorToInt(currentTime / 60);
            int remainingSeconds = Mathf.FloorToInt(currentTime % 60);

            // Display the time in the desired format
            timerText.text = string.Format("{0:00}:{1:00}", remainingMinutes, remainingSeconds);
        }

        // Check if the timer has reached zero
        if (currentTime <= 0)
        {
            // Do something when the timer reaches zero (e.g., end the game)
           // Debug.Log("Time's up!");
        }
    }
}

