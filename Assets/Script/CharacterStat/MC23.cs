using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC23 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC23";
        Character_Lv = 1;
        Job = 4;
        Grade = 4;
        MaxHealth = 600.0f;
        CurrentHealth = MaxHealth;
        Attack = 65.0f;
        NeedExp = new int[70];
        Guard = 10.0f;
        AttackSpeed = 1.3f;
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
