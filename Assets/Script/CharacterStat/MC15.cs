using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC15 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC15";
        Character_Lv = 1;
        Job = 1;
        Grade = 2;
        MaxHealth = 450.0f;
        CurrentHealth = MaxHealth;
        Attack = 45.0f;
        NeedExp = new int[60];
        Guard = 6.0f;
        AttackSpeed = 1.1f;
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
