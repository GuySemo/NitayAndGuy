using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUpdater : MonoBehaviour
{
    public static bool level1 = false;
    public static bool level2 = false;
    public static bool level3 = false;
    public static bool[] levelsCleared = { level1, level2,level3 };
    

    [SerializeField] GameObject[] flags;
    void Start()
    {
        for (int i = 0; i < levelsCleared.Length; i++)
        {
            flags[i].SetActive(levelsCleared[i]);
        }
    }

}
