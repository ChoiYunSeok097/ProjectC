using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02 : EnemyManager
{

    private void Awake()
    {
        MobName = "Boss02";
        MaxHealth = 800.0f;
        Attack = 70.0f;
        Guard = 15.0f;
        CurrentHealth = MaxHealth;
        AttackSpeed = 1f;
        SkillCooltime = 0f;
        BossJob = 1;
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
