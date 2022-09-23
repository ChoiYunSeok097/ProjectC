using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC08 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC08";
        Character_Lv = 1;
        Job = 2;
        Grade = 1;
        MaxHealth = 350.0f;
        CurrentHealth = MaxHealth;
        Attack = 35.0f;
        NeedExp = new int[50];
        Guard = 5.0f;
        AttackSpeed = 1.0f;
        LevelST();
    }

    private void Start()
    {
        Weapon1(Weapon1);
        Weapon2(Weapon2);
    }

    private void Update()
    {
        LevelUp();
    }
    private void LateUpdate()
    {
        Wars();
    }

}
