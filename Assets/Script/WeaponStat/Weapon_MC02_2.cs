using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MC02_2 : WeaponManager
{
    // Start is called before the first frame update
    void Awake()
    {
        type = 2;
        Attack = 1f;
        Health = 30f;
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
