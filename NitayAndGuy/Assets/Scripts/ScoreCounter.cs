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
        GetComponent<TMP_Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ScoreCheck()
    {
        if (score >= scoreNeeded)
        {
            Debug.Log("V");
            Win();
        }
        else
        {
            Debug.Log("X");
            Lose();
        }
    }
    public void AddScore(int num)
    {
        score = score + num;
        GetComponent<TMP_Text>().text = score.ToString();
    }
    public void Win()
    {
        Debug.Log("Win activated");
        WinPanel.SetActive(true);
        FindObjectOfType<Coins>().AddCoins(score / 10);
        Time.timeScale = 0.1f;
    }
    public void Lose()
    {
        Debug.Log("Lose activated");
        LosePanel.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
