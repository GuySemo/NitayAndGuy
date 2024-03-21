using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazerSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Slider>().maxValue= MilkGun.maxCharge;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = MilkGun.maxCharge- MilkGun.timeOfUse;
    }
}
