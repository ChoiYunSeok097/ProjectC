using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon_MC01_1 : WeaponManager
{
    void Awake()
    {
        type = 0;
        Attack = 30f;
        Health = 10f;
        Guard = 1f;
        Weapons_Lv = 1;
        NeedExp = new int[30];
        LevelST();
    }

    void Update()
    {
        LevelUp();
    }
}
