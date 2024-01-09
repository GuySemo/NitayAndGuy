using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    public int scoreNeeded;
    [SerializeField] GameObject WinPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        WinPanel.SetActive(false);
        GetComponent<TMP_Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore(int num)
    {
        score = score + num;
        GetComponent<TMP_Text>().text = score.ToString();

        if (score >= scoreNeeded)
        {
            Win();
        }
    }
    public void Win()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
