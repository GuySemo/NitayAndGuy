using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttonControl : MonoBehaviour
{
    public bool isEgg = false;
    [SerializeField] static int EggCost =50;
    [SerializeField]  TMP_Text EggCostText;

    // Start is called before the first frame update
    void Start()
    {
        if (isEgg)
        {
            gameObject.GetComponent<Button>().interactable = Coins.coins >= EggCost;
            EggCostText.text = "Cost: " + EggCost;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void buyItem()
    {
        Debug.Log(EggCost);
        FindObjectOfType<Coins>().LoseCoins(EggCost);
        Nball.sizeSpeed = Nball.sizeSpeed - 5;
        Debug.Log(Nball.sizeSpeed);
        gameObject.GetComponent<Button>().interactable = Coins.coins >= EggCost;
        EggCost *=  2;
        Debug.Log(EggCost);
        EggCostText.text = "Cost: " + EggCost;
    }
}
