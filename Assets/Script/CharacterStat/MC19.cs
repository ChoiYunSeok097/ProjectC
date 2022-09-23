using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC19 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC19";
        Character_Lv = 1;
        Job = 2;
        Grade = 3;
        MaxHealth = 700.0f;
        CurrentHealth = MaxHealth;
        Attack = 60.0f;
        NeedExp = new int[70];
        Guard = 15.0f;
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
        if (Input.GetKeyDown(KeyCode.H))
        {
            Skill(Job);
        }
    }
    private void LateUpdate()
    {
        Wars();
    }

}
