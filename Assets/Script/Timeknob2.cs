using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeknob2 : MonoBehaviour
{
    public Transform knob;  // Reference to the knob object
    public GameObject TimeCanvas;
    public AudioSource Audio;
    public List<AudioClip> Auidos;
    public float rotationSpeed = 10f;  // Speed of rotation in degrees per second
    private int minutes = 0;
    private int seconds = 0;
    private int S = 0;
    public Text Seconds;
    public Text Minute;
    public Text timerText;
    private float currentTime;
    public bool Sound = false;
    bool invoke = false;
    public bool SetTime;
    public static Timeknob2 instance;
    private void Awake()
    {
        instance = this;
    }

    public void LoadedTime()
    {
        seconds = PlayerPrefs.GetInt("Second2", 0);
        minutes = PlayerPrefs.GetInt("Minute2", 0);
        currentTime = minutes * 60 + seconds;
        Minute.text = minutes.ToString();
        Seconds.text = seconds.ToString();
        if (currentTime > 0)
        {
            TimeCanvas.SetActive(true);
        }
    }

    private void Update()
    {
        if (!SetTime)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;

                // Calculate remaining minutes and seconds
                int remainingMinutes = Mathf.FloorToInt(currentTime / 60);
                int remainingSeconds = Mathf.FloorToInt(currentTime % 60);
                PlayerPrefs.SetInt("Minute2", remainingMinutes);
                PlayerPrefs.SetInt("Second2", remainingSeconds);
                // Display the time in the desired format
                if (remainingMinutes <= 0 && remainingSeconds <= 0)
                {
                    Sound = true;
                    remainingSeconds = 0;
                    remainingMinutes = 0;
                    currentTime = remainingMinutes * 60 + remainingSeconds;
                }
                timerText.text = string.Format("{0:00}:{1:00}", remainingMinutes, remainingSeconds);
            }
            else
            {
                if (Sound)
                {
                    PlayerPrefs.SetInt("Minute2", 0);
                    PlayerPrefs.SetInt("Second2", 0);
                    print(" sound Start");
                    Audio.clip = Auidos[0];
                    if (!Audio.isPlaying)
                    {
                        Audio.Play();
                        Audio.loop = true;
                    }
                    Sound = false;
                        Invoke("SoundClose", 5f);
                        invoke = false;
                   
                }
            }
        }
    }
    public void SoundClose()
    {
        Audio.clip = Auidos[0];
        Audio.Stop();
        Audio.loop = false;
    }
    public void CurrentTime()
    {
        seconds = PlayerPrefs.GetInt("Second2", 0);
        minutes = PlayerPrefs.GetInt("Minute2", 0);
        Minute.text = minutes.ToString("D2");
        int roundedSeconds = ((seconds + 5) / 10) * 10;
        seconds = roundedSeconds;
        Seconds.text = roundedSeconds.ToString();
        SetTime = true;
    }
    public void IncreaseMinutes()
    {
        minutes++;
        RotateKnob(180f);
        Minute.text = minutes.ToString();
        PlayerPrefs.SetInt("Minute2", minutes);
    }

    public void DecreaseMinutes()
    {
        if (minutes > 0)
        {
            minutes--;
            RotateKnob(-180f);
            Minute.text = minutes.ToString();
            PlayerPrefs.SetInt("Minute2", minutes);
        }
        else
        {
            minutes = 0;
            PlayerPrefs.SetInt("Minute2", minutes);
        }
    }

    public void IncreaseSeconds()
    {
        S++;
        seconds += 10;
        if (S == 6)
        {
            RotateKnob(36f);
            seconds = 0;
            Seconds.text = seconds.ToString();
            minutes++;
            Minute.text = minutes.ToString();
            S = 0;
            PlayerPrefs.SetInt("Minute2", minutes);
            PlayerPrefs.SetInt("Second2", seconds);
        }
        else
        {
            RotateKnob(36f);
            Seconds.text = seconds.ToString();
            PlayerPrefs.SetInt("Second2", seconds);
        }
    }

    public void DecreaseSeconds()
    {

        seconds -= 10;

        if (seconds == -10 && minutes > 0)
        {
            S = 5;
            RotateKnob(-36f);
            seconds = 50;
            Seconds.text = seconds.ToString();
            minutes--;
            Minute.text = minutes.ToString();
            PlayerPrefs.SetInt("Minute2", minutes);
            PlayerPrefs.SetInt("Second2", seconds);
        }
        else if (seconds >= 0)
        {
            S--;
            RotateKnob(-36f);
            Seconds.text = seconds.ToString();
            PlayerPrefs.SetInt("Second2", seconds);
        }
        else
        {
            seconds = 0;
            PlayerPrefs.SetInt("Second2", seconds);
        }
    }

    public void StartTimer()
    {
        seconds = PlayerPrefs.GetInt("Second2", 0);
        minutes = PlayerPrefs.GetInt("Minute2", 0);
        print(" Minute Value" + minutes + " .Second value " + seconds);
        currentTime = minutes * 60 + seconds;
        TimeCanvas.SetActive(true);
        SetTime = false;
    }

    private void RotateKnob(float angle)
    {
        knob.Rotate(Vector3.up, angle);
    }
}
