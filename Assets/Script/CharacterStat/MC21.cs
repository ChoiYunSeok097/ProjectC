using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MC21 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC21";
        Character_Lv = 1;
        Job = 4;
        Grade = 3;
        MaxHealth = 500.0f;
        CurrentHealth = MaxHealth;
        Attack = 50.0f;
        NeedExp = new int[70];
        Guard = 8.0f;
        AttackSpeed = 1.3f;
        AttackRange = 20f;
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            Skill(Job);
        }
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
