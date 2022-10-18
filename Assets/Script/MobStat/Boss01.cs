using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss01 : EnemyManager
{

    private void Awake()
    {
        MobName = "Boss01";
        MaxHealth = 600.0f;
        Attack = 40.0f;
        Guard = 8.0f;
        CurrentHealth = MaxHealth;
        AttackSpeed = 0.8f;
        SkillCooltime = 0f;
        BossJob = 0;
        AttackRange = 3f;
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
            BossSkill(BossJob);
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
