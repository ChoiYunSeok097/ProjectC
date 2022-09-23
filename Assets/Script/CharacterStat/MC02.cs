using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC02 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC02";
        Character_Lv = 1;
        Job = 0;
        Grade = 1;
        MaxHealth = 200.0f;
        CurrentHealth = MaxHealth;
        Attack = 20.0f;
        NeedExp = new int[50];
        Guard = 3.0f;
        AttackSpeed = 1.0f;
        LevelST();
    }

    private void Start()
    {
        Weapon1(Weapon1);
        Weapon2(Weapon2);
        Debug.Log("B name : " + CharName + MaxHealth + Attack);
    }

    private void Update()
    {
        LevelUp();
    }
    private void LateUpdate()
    {
        Wars();
    }

}
