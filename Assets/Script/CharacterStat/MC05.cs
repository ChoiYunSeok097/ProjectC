using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MC05 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC05";
        Character_Lv = 1;
        Job = 3;
        Grade = 2;
        MaxHealth = 500.0f;
        CurrentHealth = MaxHealth;
        Attack = 50.0f;
        NeedExp = new int[60];
        Guard = 8.0f;
        AttackSpeed = 0.8f;
        AttackRange = 3.5f;
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
