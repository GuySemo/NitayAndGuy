using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttonControl : MonoBehaviour
{
    static int speedUpgrade = 0;
    public bool isEgg = false;
    [SerializeField] static int EggCost =35;
    [SerializeField]  TMP_Text EggCostText;
    [SerializeField] TMP_Text SpeedNumTxt;

    static int DelayUpgrade = 3;
    [SerializeField] static int EggDelayCost = 25;
    [SerializeField] TMP_Text EggDelayText;
    [SerializeField] TMP_Text DelayNumTxt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isEgg)
        {
            SpeedNumTxt.text = "Egg Speed: " + (speedUpgrade + 1).ToString() + " (+) ";
            if (speedUpgrade <=2)
            {
                gameObject.GetComponent<Button>().interactable = Coins.coins >= EggCost;
                EggCostText.text = "Cost: " + EggCost;
            }
            else
            {
                EggCostText.text = "Max";
                gameObject.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            DelayNumTxt.text = "Egg Delay: " + (DelayUpgrade ).ToString() + " (-) ";
            if (DelayUpgrade >= 1)
            {
                gameObject.GetComponent<Button>().interactable = Coins.coins >= EggDelayCost;
                EggDelayText.text = "Cost: " + EggDelayCost;
            }
            else
            {
                EggDelayText.text = "Max";
                gameObject.GetComponent<Button>().interactable = false;
            }
        }

    }

    public void buyItem()
    {
        if (speedUpgrade <=3)
        {
            speedUpgrade++;
            FindObjectOfType<Coins>().LoseCoins(EggCost);
            Nball.sizeSpeed = Nball.sizeSpeed + 1.5f;
            EggCost *= 2;
            gameObject.GetComponent<Button>().interactable = (Coins.coins >= EggCost);
            EggCostText.text = "Cost: " + EggCost;
        }
        else
        {
            EggCostText.text = "Max";
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void buyDelay()
    {
        if (DelayUpgrade >=1)
        {
            DelayUpgrade--;
            FindObjectOfType<Coins>().LoseCoins(EggDelayCost);
            Nonclick.cooldown = Nonclick.cooldown - 0.075f;
            EggDelayCost *= 2;
            gameObject.GetComponent<Button>().interactable = (Coins.coins >= EggDelayCost);
            EggDelayText.text = "Cost: " + EggDelayCost;
        }
        else
        {
            EggDelayText.text = "Max";
            gameObject.GetComponent<Button>().interactable = false;
        }

    }
}
