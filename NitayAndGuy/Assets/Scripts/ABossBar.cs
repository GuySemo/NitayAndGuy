using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABossBar : MonoBehaviour
{
    [SerializeField] GameObject King;
    int temp = 1200;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().maxValue = King.GetComponent<AlienScript>().life;
    }

    // Update is called once per frame
    void Update()
    {
        if (temp > 1)
        {
            GetComponent<Slider>().value = (int)(King.GetComponent<AlienScript>().life);
            temp = (int)(King.GetComponent<AlienScript>().life);
        }
    }
}
