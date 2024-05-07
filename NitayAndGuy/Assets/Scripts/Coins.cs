using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public static int coins = 0;

    private void Start()
    {
        ShowCoins();
    }
    public void ShowCoins()
    {
        GetComponent<TMP_Text>().text = coins.ToString();
    }
    public void AddCoins(int amount)
    {
        coins = coins + amount;
        ShowCoins();
        //levelLoader.SaveGame();
    }
    public void LoseCoins(int amount)
    {
        coins = coins - amount;
        ShowCoins();
        //levelLoader.SaveGame();
    }
}
