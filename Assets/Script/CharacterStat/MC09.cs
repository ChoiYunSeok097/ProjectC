using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC09 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC09";
        Character_Lv = 1;
        Job = 2;
        Grade = 4;
        MaxHealth = 600.0f;
        CurrentHealth = MaxHealth;
        Attack = 65.0f;
        NeedExp = new int[70];
        Guard = 10.0f;
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Skill(Job);
        }
    }
    private void LateUpdate()
    {
        Wars();
    }

}
