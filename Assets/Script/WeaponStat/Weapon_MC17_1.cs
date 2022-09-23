using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon_MC17_1 : WeaponManager
{
    void Awake()
    {
        type = 0;
        Attack = 20f;
        Health = 12f;
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
