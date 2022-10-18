using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MC10 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC10";
        Character_Lv = 1;
        Job = 1;
        Grade = 3;
        MaxHealth = 550.0f;
        CurrentHealth = MaxHealth;
        Attack = 50.0f;
        NeedExp = new int[70];
        Guard = 8.0f;
        AttackSpeed = 1.0f;
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
        if (Input.GetKeyDown(KeyCode.W))
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
