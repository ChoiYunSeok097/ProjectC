using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC03 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC03";
        Character_Lv = 1;
        Job = 6;
        Grade = 1;
        MaxHealth = 150.0f;
        CurrentHealth = MaxHealth;
        Attack = 20.0f;
        NeedExp = new int[50];
        Guard = 2.0f;
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            Skill(Job);
        }
    }
    private void LateUpdate()
    {
        Wars();
    }

}
