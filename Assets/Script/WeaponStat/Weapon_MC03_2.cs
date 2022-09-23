using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MC03_2 : WeaponManager
{
    // Start is called before the first frame update
    void Awake()
    {
        type = 0;
        Attack = 1f;
        Health = 20f;
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
