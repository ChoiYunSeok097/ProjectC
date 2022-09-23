using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MC16_1 : WeaponManager

{
    // Start is called before the first frame update
    void Awake()
    {
        type = 5;
        Attack = 60f;
        Health = 10f;
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
