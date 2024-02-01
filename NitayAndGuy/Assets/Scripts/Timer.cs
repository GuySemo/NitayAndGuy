using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] float secondsSinceStart;

    [SerializeField] int seconds = 90;
    private int secondsSave;
    public bool started = false;
    string secondsText = null;

    bool stopped = false;
    // Start is called before the first frame update
    void Start()
    {
        secondsSave = seconds;
        if (seconds % 60 > 9)
        {
            secondsText = (seconds / 60) + ":" + (seconds % 60);
        }
        else
        {
            secondsText = (seconds / 60) + ":0" + (seconds % 60);
        }
        GetComponent<TMP_Text>().text = secondsText; GetComponent<TMP_Text>().text = secondsText;

        secondsSinceStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - secondsSinceStart > 1 
            && seconds>0 
            && started)
        {
            secondsSinceStart = Time.time + 1;
            seconds = seconds - 1;
            DisplayTime(seconds);

            if (seconds == secondsSave / 5)
            {
                FindObjectOfType<spawno>().reduceDelay(1.5f);
            }
            else if (seconds == secondsSave/2)
            {
                FindObjectOfType<spawno>().reduceDelay(1.5f);
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 ||
            SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (seconds <= 0 && !stopped)
            {
                //Stop Game
                FindObjectOfType<ScoreCounter>().ScoreCheck();
                stopped = true;
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (FindObjectOfType<ScoreCounter>().score >= FindObjectOfType<ScoreCounter>().scoreNeeded)
            {
                FindObjectOfType<ScoreCounter>().ScoreCheck();
            }
        }

    }
    public void DisplayTime(int seconds)
    {
        if (seconds % 60 > 9)
        {
           secondsText = (seconds / 60) + ":" + (seconds%60)/10 + (seconds%60)%10;
        }
        else
        {
            secondsText = (seconds / 60) + ":0" + (seconds % 60);
        }
        GetComponent<TMP_Text>().text = secondsText;
    }
}
