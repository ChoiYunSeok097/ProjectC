using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC24 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC24";
        Character_Lv = 1;
        Job = 6;
        Grade = 1;
        MaxHealth = 200.0f;
        CurrentHealth = MaxHealth;
        Attack = 30.0f;
        NeedExp = new int[50];
        Guard = 4.0f;
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
        if (Input.GetKeyDown(KeyCode.U))
        {
            Skill(Job);
        }
    }
    private void LateUpdate()
    {
        Wars();
    }

}
