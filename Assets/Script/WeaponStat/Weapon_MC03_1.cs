using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MC03_1 : WeaponManager
{
    // Start is called before the first frame update
    void Awake()
    {
        type = 0;
        Attack = 8f;
        Health = 5f;
        Guard = 0.2f;
        Weapons_Lv = 1;
        NeedExp = new int[30];
        LevelST();
    }

    void Update()
    {
        LevelUp();
    }
}
