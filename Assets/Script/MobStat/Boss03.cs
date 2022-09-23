using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03 : EnemyManager
{

    private void Awake()
    {
        MobName = "Boss03";
        MaxHealth = 500.0f;
        Attack = 50.0f;
        Guard = 10.0f;
        CurrentHealth = MaxHealth;
        AttackSpeed = 1.3f;
        SkillCooltime = 0f;
        BossJob = 2;
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
