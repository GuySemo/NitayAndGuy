using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] float secondsSinceStart;

    [SerializeField] float seconds = 50;
    // Start is called before the first frame update
    void Start()
    {
        secondsSinceStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - secondsSinceStart >1)
        {
            secondsSinceStart = secondsSinceStart + 1;
            seconds = seconds - 1;
            GetComponent<TMP_Text>().text = seconds.ToString();
        }
    }
}
