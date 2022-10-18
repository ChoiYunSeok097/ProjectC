using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MC04 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC04";
        Character_Lv = 1;
        Job = 1;
        Grade = 1;
        MaxHealth = 300.0f;
        CurrentHealth = MaxHealth;
        Attack = 30.0f;
        NeedExp = new int[50];
        Guard = 5.0f;
        AttackSpeed = 1.1f;
        AttackRange = 3f;
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
        if (Input.GetKeyDown(KeyCode.U))
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
