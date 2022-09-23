using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MC23_2 : WeaponManager
{
    // Start is called before the first frame update
    void Awake()
    {
        type = 4;
        Attack = 45f;
        Health = 20f;
        Guard = 2f;
        Weapons_Lv = 1;
        NeedExp = new int[30];
        LevelST();
    }

    void Update()
    {
        LevelUp();
    }
}
