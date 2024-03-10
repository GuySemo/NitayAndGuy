using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUpdater : MonoBehaviour
{
    public static bool level1 = false;
    public static bool level2 = false;
    public static bool level3 = false;
    public static bool level4 = false;
    public static bool level5 = false;
    public static bool level6 = false;
    public static bool level7 = false;
    public static bool level8 = false;
    public static bool level9 = false;
    public static bool level10 = false;
    public static bool level11 = false;
    public static bool level12 = false;

    public static bool[] levelsCleared = { level1, level2, level3, level4, level5, level6, level7, level8, level9, level10, level11
    };

    [SerializeField] GameObject levels;
    int levelCount;
    Transform[] levelButtons;
    void Start()
    {
        //
        levelCount = levels.transform.childCount;
        levelButtons = new Transform[levelCount];

        //Fill level Buttons array
        for (int j = 0; j < levelButtons.Length; j++)
        {
            levelButtons[j] = levels.gameObject.transform.GetChild(j);
        }
        //Set Active Flags 
        for (int i = 0; i < levelsCleared.Length; i++)
        {
            //Flags
            levelButtons[i].transform.GetChild(0).gameObject.SetActive(levelsCleared[i]);
            //Button Clickable
            levelButtons[i + 1].GetComponent<Clickables>().canClick = levelsCleared[i];
            levelButtons[i + 1].GetComponent<Clickables>().ReColor();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UnlockAll();
        }
    }
    public void UnlockAll()
    {
        //Button Clickable
        for (int i = 0; i < levelsCleared.Length; i++)
        {
            //Button Clickable
            levelButtons[i + 1].GetComponent<Clickables>().canClick = true;
            levelButtons[i + 1].GetComponent<Clickables>().ReColor();
        }
        Coins.coins = 1000000;
    }

}
