using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2Shop : MonoBehaviour
{
    public static bool unlocked = false;
    [SerializeField] GameObject bananas;
    // Start is called before the first frame update
    void Start()
    {
        if (MapUpdater.freePlay)
        {
            GetComponent<W2Shop>().enabled = false;
        }
        GetComponent<Clickables>().canClick = false;
        if (unlocked)
        {
            UnlockShop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UnlockShop()
    {
        unlocked = true;
        GetComponent<Clickables>().canClick = true;
        GetComponent<Clickables>().ReColor();
        bananas.SetActive(false);
    }
}
