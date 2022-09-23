using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MC20_2 : WeaponManager
{
    // Start is called before the first frame update
    void Awake()
    {
        type = 2;
        Attack = 5f;
        Health = 70f;
        Guard = 15f;
        Weapons_Lv = 1;
        NeedExp = new int[30];
        LevelST();
    }

    void Update()
    {
        LevelUp();
    }
}
