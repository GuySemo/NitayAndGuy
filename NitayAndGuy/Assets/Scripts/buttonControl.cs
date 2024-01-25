using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttonControl : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField]  TMP_Text costText;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().interactable = Coins.coins >= cost;
        costText.text = "Cost: " + cost;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void buyItem()
    {
        Debug.Log(cost);
        FindObjectOfType<Coins>().LoseCoins(cost);
        Nball.sizeSpeed = Nball.sizeSpeed - 5;
        Debug.Log(Nball.sizeSpeed);
        gameObject.GetComponent<Button>().interactable = Coins.coins >= cost;
        cost = cost * 2;
        Debug.Log(cost);
        costText.text = "Cost: " + cost;
    }
}
