using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MC07 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        CharName = "MC07";
        Character_Lv = 1;
        Job = 5;
        Grade = 3;
        MaxHealth = 300.0f;
        CurrentHealth = MaxHealth;
        Attack = 60.0f;
        NeedExp = new int[70];
        Guard = 5.0f;
        AttackSpeed = 0.8f;
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
        if (Input.GetKeyDown(KeyCode.Y))
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
