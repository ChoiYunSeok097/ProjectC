using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC01 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake() 
    {
        CharName = "MC01";
        Character_Lv = 1;
        Job = 0;
        Grade = 2;
        MaxHealth = 300.0f;
        CurrentHealth = 30f;
        Attack = 30.0f;
        NeedExp = new int[60];
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            Skill(Job);
        }
    }
    private void LateUpdate()
    {
        Wars();
    }
}
