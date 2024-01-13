using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;

public class buttonControl : MonoBehaviour
{
    [SerializeField] int cost=5;
    public int money = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Button>().interactable = money > cost;
    }

    public void buyItem(int cost)
    {
        money = money - cost;
     //FindObjectOfType<Nonclick>().upgradeSpeed();
    }
}
