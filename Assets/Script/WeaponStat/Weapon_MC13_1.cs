using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MC13_1 : WeaponManager
{
    // Start is called before the first frame update
    void Awake()
    {
        type = 3;
        Attack = 25f;
        Health = 15f;
        Guard = 3f;
        Weapons_Lv = 1;
        NeedExp = new int[30];
        LevelST();
    }

    void Update()
    {
        LevelUp();
    }
}
