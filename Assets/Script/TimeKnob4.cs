using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeKnob4 : MonoBehaviour
{
    public Transform knob;
    public GameObject TimeCanvas;
    public float rotationSpeed = 10f;
    public AudioSource Audio;
    public List<AudioClip> Auidos;
    private int minutes;
    private int seconds;
    private int S = 0;
    public Text timerText;
    private float currentTime;
    public bool Sound = false;
    public Text Seconds;
    public Text Minute;
    public bool SetTime;
    bool invoke = false;
    public static TimeKnob4 instance;
    private void Awake()
    {
        instance = this;
    }

    public void LoadedTime()
    {
        seconds = PlayerPrefs.GetInt("Second4", 0);
        minutes = PlayerPrefs.GetInt("Minute4", 0);
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

                int remainingMinutes = Mathf.FloorToInt(currentTime / 60);
                int remainingSeconds = Mathf.FloorToInt(currentTime % 60);
                PlayerPrefs.SetInt("Minute4", remainingMinutes);
                PlayerPrefs.SetInt("Second4", remainingSeconds);
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
                    PlayerPrefs.SetInt("Minute4", 0);
                    PlayerPrefs.SetInt("Second4", 0);
                    print(" sound Start");
                    Audio.clip = Auidos[0];
                    if (!Audio.isPlaying)
                    {
                        Audio.Play();
                        Audio.loop = true;
                    }
                    Sound = false;
                        Invoke("SoundClose", 5f);
                    
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
        seconds = PlayerPrefs.GetInt("Second4");
        minutes = PlayerPrefs.GetInt("Minute4");
        Minute.text = minutes.ToString("D2");
        int roundedSeconds = ((seconds + 5) / 10) * 10;
        Seconds.text = roundedSeconds.ToString();
        SetTime = true;
    }

    public void IncreaseMinutes()
    {
        minutes++;
        RotateKnob(180f);
        Minute.text = minutes.ToString();
        PlayerPrefs.SetInt("Minute4", minutes);
    }

    public void DecreaseMinutes()
    {
        if (minutes > 0)
        {
            minutes--;
            RotateKnob(-180f);
            Minute.text = minutes.ToString();
            PlayerPrefs.SetInt("Minute4", minutes);
        }
        else
        {
            minutes = 0;
            PlayerPrefs.SetInt("Minute4", minutes);
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
            PlayerPrefs.SetInt("Minute4", minutes);
            Minute.text = minutes.ToString();
            S = 0;
            PlayerPrefs.SetInt("Second4", seconds);
        }
        else
        {
            RotateKnob(36f);
            Seconds.text = seconds.ToString();
            PlayerPrefs.SetInt("Second4", seconds);
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
            PlayerPrefs.SetInt("Minute4", minutes);
            Minute.text = minutes.ToString();
            PlayerPrefs.SetInt("Second4", seconds);
        }
        else if (seconds >= 0)
        {
            S--;
            RotateKnob(-36f);
            Seconds.text = seconds.ToString();
            PlayerPrefs.SetInt("Second4", seconds);
        }
        else
        {
            seconds = 0;
            PlayerPrefs.SetInt("Second4", seconds);
        }
    }

    public void StartTimer()
    {
        seconds = PlayerPrefs.GetInt("Second4");
        minutes = PlayerPrefs.GetInt("Minute4");
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
