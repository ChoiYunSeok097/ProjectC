using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon_MC20_1 : WeaponManager
{
    void Awake()
    {
        type = 0;
        Attack = 60f;
        Health = 20f;
        Guard = 5f;
        Weapons_Lv = 1;
        NeedExp = new int[30];
        LevelST();
    }

    void Update()
    {
        LevelUp();
    }
}
