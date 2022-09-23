using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC20 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC20";
        Character_Lv = 1;
        Job = 0;
        Grade =3;
        MaxHealth = 780.0f;
        CurrentHealth = MaxHealth;
        Attack = 50.0f;
        NeedExp = new int[70];
        Guard = 20.0f;
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
