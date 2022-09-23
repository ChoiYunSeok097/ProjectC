using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC17 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC11";
        Character_Lv = 1;
        Job = 2;
        Grade = 2;
        MaxHealth = 450.0f;
        CurrentHealth = MaxHealth;
        Attack = 40.0f;
        NeedExp = new int[60];
        Guard = 7.0f;
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            Skill(Job);
        }
    }
    private void LateUpdate()
    {
        Wars();
    }

}