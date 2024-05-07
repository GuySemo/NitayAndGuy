using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerBoss : MonoBehaviour
{
    [SerializeField] float seconds;
    float timer;
    TMP_Text myText;
    bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer > seconds  && !hit)
        {
            //Do something
            Debug.Log("Do something");
            FindObjectOfType<FinalLevelScript>().GetHit();
            hit = true;
        }
        float num = Mathf.Floor(seconds - (Time.time - timer) + 1);
        if (num >= 0)
        {
            if (num <= 9)
            {
                GetComponent<TMP_Text>().text = "0:0" + (num).ToString();
            }
            else
            {
                GetComponent<TMP_Text>().text = "0:" + (num).ToString();
            }
        }
    }
}
