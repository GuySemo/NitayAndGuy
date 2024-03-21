using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSlider : MonoBehaviour
{
    Transform Stars;
    Transform handle;
    // Start is called before the first frame update
    void Start()
    {
        Stars = gameObject.transform.GetChild(3);
        handle = gameObject.transform.GetChild(2).GetChild(0);
        
        GetComponent<Slider>().maxValue = FindObjectOfType<ScoreCounter>().threeStarPoints 
            + FindObjectOfType<ScoreCounter>().threeStarPoints/10;

        //Put Stars in place
        GetComponent<Slider>().value = FindObjectOfType<ScoreCounter>().scoreNeeded;
        Stars.GetChild(0).transform.position = handle.transform.position;

        GetComponent<Slider>().value = FindObjectOfType<ScoreCounter>().twoStarPoints;
        Stars.GetChild(1).transform.position = handle.transform.position;

        GetComponent<Slider>().value = FindObjectOfType<ScoreCounter>().threeStarPoints;
        Stars.GetChild(2).transform.position = handle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = FindObjectOfType<ScoreCounter>().score;
    }
}
