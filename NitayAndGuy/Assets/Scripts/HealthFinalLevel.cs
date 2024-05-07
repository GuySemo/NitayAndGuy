using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthFinalLevel : MonoBehaviour
{
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoseHeart()
    {
        health--;
        GetComponent<TMP_Text>().text = health.ToString();
        if (health <= 0)
        {
            FindObjectOfType<ScoreCounter>().Lose();
        }
    }
}
