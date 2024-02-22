using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    public int scoreNeeded;
    [SerializeField]  public int twoStarPoints;
    [SerializeField]  public int threeStarPoints;

    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;

    [SerializeField] GameObject[] Stars;
    [SerializeField] TMP_Text CoinsText;
    // Start is called before the first frame update
    void Start()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);

        Time.timeScale = 1;
        GetComponent<TMP_Text>().text = score.ToString();

        for (int i = 0; i < Stars.Length; i++)
        {
            Stars[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ScoreCheck()
    {
        if (score >= scoreNeeded)
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
    }
    public void RemoveScore(int num)
    {
        score = score - num;
        GetComponent<TMP_Text>().text = score.ToString();
    }
    public void Win()
    {
        Debug.Log("Win activated");
        WinPanel.SetActive(true);
        Time.timeScale = 0.1f;

        if (score > scoreNeeded + threeStarPoints)//Three Stars
        {
            FindObjectOfType<Coins>().AddCoins(100);
            CoinsText.text = "+" + 100 + " Coins";
            //Stars
            Stars[2].SetActive(true);
            Stars[1].SetActive(true);
            Stars[0].SetActive(true);
        }
        else if (score > scoreNeeded + twoStarPoints)//Two Stars
        {
            FindObjectOfType<Coins>().AddCoins(75);
            CoinsText.text = "+" + 75 + " Coins";
            //Stars

            Stars[1].SetActive(true);
            Stars[0].SetActive(true);
        }
        else if (score >= scoreNeeded)//One Star
        {
            FindObjectOfType<Coins>().AddCoins(50);
            CoinsText.text = "+" + 50 + " Coins";
            //Stars
            Stars[0].SetActive(true);
        }
    }
    public void Lose()
    {
        Debug.Log("Lose activated");
        LosePanel.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
