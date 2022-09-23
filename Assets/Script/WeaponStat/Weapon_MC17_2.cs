using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon_MC17_2 : WeaponManager
{
    void Awake()
    {
        type = 0;
        Attack = 22f;
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
