using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    //General Data
    public int coins;
    public bool[] levelsUnlocked;
    //public float[] cameraPos;
    public bool destroyFogW2;
    public bool destroyFogW3;

    //Upgrades
    public float eggSpeed;
    //World1
    public int eggCost;
    public int speedUpgrade;
    public int delayCost;
    public int delayUpgrade;
    //World2
    public int bananaCost;
    public int bananaUpgrade;
    public int pointCost;
    public int pointUpgrade;

    //public PlayerData(MCameraMove camera)
    //{
    //    coins = Coins.coins;
    //    levelsUnlocked = MapUpdater.levelsCleared;
    //    destroyFogW2 = MapUpdater.destoryFogW2;
    //    destroyFogW3 = MapUpdater.destoryFogW3;

    //    eggSpeed = Nball.sizeSpeed;

    //}
}
