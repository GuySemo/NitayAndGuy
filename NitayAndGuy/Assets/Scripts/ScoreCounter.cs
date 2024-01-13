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
    [SerializeField] GameObject LosePanel;
    // Start is called before the first frame update
    void Start()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);

        Time.timeScale = 1;
        WinPanel.SetActive(false);
        GetComponent<TMP_Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ScoreCheck()
    {
        if (score > scoreNeeded)
        {
            Win();
        }
        else
        {
            Lose();
        }
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
    public void Lose()
    {
        LosePanel.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
