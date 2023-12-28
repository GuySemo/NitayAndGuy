using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (5<Time.time&& flag)
        {
            flag= false;
            AddScore(4000);
        }

    }
    public void AddScore(int num)
    {
        score = score + num;
        GetComponent<TMP_Text>().text = score.ToString();


    }
}
