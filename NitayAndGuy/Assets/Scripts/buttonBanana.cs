using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttonBanana : MonoBehaviour
{
    static int amountUpgrade = 0;
    public bool isBanana = false;
     static int BananaCost = 200;
    [SerializeField] TMP_Text BananaCostText;
    [SerializeField] TMP_Text AmountNumTxt;

    static int PointUpgrade = 0;
    [SerializeField] static int BananaPointCost = 60;
    [SerializeField] TMP_Text BananaPointText;
    [SerializeField] TMP_Text PointNumTxt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isBanana)
        {
            AmountNumTxt.text = "Bananas: " + (amountUpgrade + 1).ToString() + " (+) ";
            if (amountUpgrade <= 1)
            {
                gameObject.GetComponent<Button>().interactable = Coins.coins >= BananaCost;
                BananaCostText.text = "Cost:" + BananaCost;
            }
            else
            {
                BananaCostText.text = "Max";
                gameObject.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            PointNumTxt.text = "Banana Points: " + (PointUpgrade + 1).ToString() + " (+) ";
            if (PointUpgrade <= 2)
            {
                gameObject.GetComponent<Button>().interactable = Coins.coins >= BananaPointCost;
                BananaPointText.text = "Cost:" + BananaPointCost;
            }
            else
            {
                BananaPointText.text = "Max";
                gameObject.GetComponent<Button>().interactable = false;
            }
        }

    }

    public void UpgradeDamage()
    {
        if (amountUpgrade <= 1)
        {
            amountUpgrade++;
            FindObjectOfType<Coins>().LoseCoins(BananaCost);
            BananaOnClick.bananasAllowed++;
            BananaCost *= 2;
            gameObject.GetComponent<Button>().interactable = (Coins.coins >= BananaCost);
            BananaCostText.text = "Cost: " + BananaCost;
        }
        else
        {
            BananaCostText.text = "Max";
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void buyDelay()
    {
        if (PointUpgrade <= 4)
        {
            PointUpgrade++;
            FindObjectOfType<Coins>().LoseCoins(BananaPointCost);
            NormalMonkey.maxPoints = NormalMonkey.maxPoints + 7;
            WalkingMonkey.maxPoints = WalkingMonkey.maxPoints + 7;
            BananaPointCost *= 2;
            gameObject.GetComponent<Button>().interactable = (Coins.coins >= BananaPointCost);
            BananaPointText.text = "Cost: " + BananaPointCost;
        }
        else
        {
            BananaPointText.text = "Max";
            gameObject.GetComponent<Button>().interactable = false;
        }

    }
}
