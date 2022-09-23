using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MC24_1 : WeaponManager
{
    // Start is called before the first frame update
    void Awake()
    {
        type = 5;
        Attack = 20f;
        Health = 5f;
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
