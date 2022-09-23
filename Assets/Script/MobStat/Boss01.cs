using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Wars();
    }
}
