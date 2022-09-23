using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MC10_2 : WeaponManager
{
    // Start is called before the first frame update
    void Awake()
    {
        type = 6;
        Attack = 8f;
        Health = 70f;
        Guard = 7f;
        Weapons_Lv = 1;
        NeedExp = new int[30];
        LevelST();
    }

    void Update()
    {
        LevelUp();
    }
}
