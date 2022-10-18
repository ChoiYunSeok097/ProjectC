using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MC06 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC06";
        Character_Lv = 1;
        Job = 5;
        Grade = 2;
        MaxHealth = 500.0f;
        CurrentHealth = MaxHealth;
        Attack = 50.0f;
        NeedExp = new int[50];
        Guard = 8.0f;
        AttackSpeed = 1.0f;
        AttackRange = 15f;
        pathFinder = GetComponent<NavMeshAgent>();
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
    }
    private void LateUpdate()
    {
        NavMove();
        if (!canmove)
        {
            Wars();
        }
        else
        {
            time = 0;
        }
    }

}
