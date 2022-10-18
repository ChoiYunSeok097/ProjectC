using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MC11 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC11";
        Character_Lv = 1;
        Job = 4;
        Grade = 1;
        MaxHealth = 200.0f;
        CurrentHealth = MaxHealth;
        Attack = 25.0f;
        NeedExp = new int[50];
        Guard = 3.0f;
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
        if (Input.GetKeyDown(KeyCode.Z))
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
