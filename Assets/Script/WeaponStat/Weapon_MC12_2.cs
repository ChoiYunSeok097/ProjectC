using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MC12_2 : WeaponManager
{
    // Start is called before the first frame update
    void Awake()
    {
        type = 6;
        Attack = 4f;
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
