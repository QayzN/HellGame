using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;


    public GameObject player;

    private bool timerOn;


    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        timerOn = true;
    }

    void Update()
    {

       timeRemaining += Time.deltaTime;
       DisplayTime(timeRemaining);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Grim")
        {
            timerOn = false;
        }
    }

    void DisplayTime(float timeToDisplay)
    {


        timeToDisplay += 000001;

        if (timerOn == true)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            float milliSeconds = (timeToDisplay % 1) * 1000;

            timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
        }
    }
}