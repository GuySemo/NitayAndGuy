using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttonBanana : MonoBehaviour
{
    static int damageUpgrade = 0;
    public bool isBanana = false;
     static int BananaCost = 40;
    [SerializeField] TMP_Text BananaCostText;
    [SerializeField] TMP_Text DamageNumTxt;

    static int DelayUpgrade = 3;
    [SerializeField] static int BananaDelayCost = 25;
    [SerializeField] TMP_Text BananaDelayText;
    [SerializeField] TMP_Text DelayNumTxt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isBanana)
        {
            DamageNumTxt.text = "Banana Damage: " + (damageUpgrade + 1).ToString() + " (+) ";
            if (damageUpgrade <= 2)
            {
                gameObject.GetComponent<Button>().interactable = Coins.coins >= BananaCost;
                BananaCostText.text = "Cost: " + BananaCost;
            }
            else
            {
                BananaCostText.text = "Max";
                gameObject.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            DelayNumTxt.text = "Banana Delay: " + (DelayUpgrade).ToString() + " (-) ";
            if (DelayUpgrade >= 1)
            {
                gameObject.GetComponent<Button>().interactable = Coins.coins >= BananaDelayCost;
                BananaDelayText.text = "Cost: " + BananaDelayCost;
            }
            else
            {
                BananaDelayText.text = "Max";
                gameObject.GetComponent<Button>().interactable = false;
            }
        }

    }

    public void UpgradeDamage()
    {
        if (damageUpgrade <= 3)
        {
            damageUpgrade++;
            FindObjectOfType<Coins>().LoseCoins(BananaCost);
            //Gbanana.myDamage=Gbanana.myDamage*2;
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
        if (DelayUpgrade >= 1)
        {
            DelayUpgrade--;
            FindObjectOfType<Coins>().LoseCoins(BananaDelayCost);
            BananaOnClick.cooldown = BananaOnClick.cooldown - 0.2f;
            BananaDelayCost *= 2;
            gameObject.GetComponent<Button>().interactable = (Coins.coins >= BananaDelayCost);
            BananaDelayText.text = "Cost: " + BananaDelayCost;
        }
        else
        {
            BananaDelayText.text = "Max";
            gameObject.GetComponent<Button>().interactable = false;
        }

    }
}
