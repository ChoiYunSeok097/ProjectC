using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob11 : EnemyManager
{

    private void Awake()
    {
        MobName = "Mob11";
        MaxHealth = 300.0f;
        Attack = 40.0f;
        Guard = 5.0f;
        CurrentHealth = MaxHealth;
        AttackSpeed = 1.3f;
        SkillCooltime = 0f;
        Job = 1;
        AttackRange = 20f;
        pathFinder = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        //StageStat(int stage)
    }
    private void Update()
    {
        SkillCooltime += Time.deltaTime;
        if (SkillCooltime > 15f)
        {
            Skill(Job);
            SkillCooltime -= 15f;
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
