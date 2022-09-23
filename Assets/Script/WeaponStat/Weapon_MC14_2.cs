using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MC14_2 : WeaponManager
{
    // Start is called before the first frame update
    void Awake()
    {
        type = 6;
        Attack = 3f;
        Health = 50f;
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
