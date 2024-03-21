using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Slider>().maxValue = 100;
        gameObject.GetComponent<Slider>().value = 100;

    }

    // Update is called once per frame
    void Update()
    {
        if (ChickenBoss.spawned )
        {
            if (FindObjectOfType<ChickenBoss>().life > 1)
            {
                gameObject.GetComponent<Slider>().value = FindObjectOfType<ChickenBoss>().life;
            }
        }
    }
}
