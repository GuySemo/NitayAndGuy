using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] float secondsSinceStart;

    [SerializeField] int seconds = 90;
    public bool started = false;
    string secondsText = null;
    // Start is called before the first frame update
    void Start()
    {
        secondsText = (seconds / 60) + ":" + (seconds - 60 * (seconds / 60));
        GetComponent<TMP_Text>().text = secondsText;
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
        }
        if (seconds <= 0 )
        {
            //Stop Game
            Time.timeScale = 0.01f;
        }

    }
    public void DisplayTime(int seconds)
    {
        if (seconds % 60 > 9)
        {
           secondsText = (seconds / 60) + ":" + (seconds%60);
        }
        else
        {
            secondsText = (seconds / 60) + ":0" + (seconds % 60);
        }
        GetComponent<TMP_Text>().text = secondsText;
    }
}
