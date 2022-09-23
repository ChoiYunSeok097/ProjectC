using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC12 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC12";
        Character_Lv = 1;
        Job = 3;
        Grade = 1;
        MaxHealth = 350.0f;
        CurrentHealth = MaxHealth;
        Attack = 35.0f;
        NeedExp = new int[50];
        Guard = 5.0f;
        AttackSpeed = 0.8f;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            Skill(Job);
        }
    }
    private void LateUpdate()
    {
        Wars();
    }

}
