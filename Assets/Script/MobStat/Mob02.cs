using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob02 : EnemyManager
{

    private void Awake()
    {
        MobName = "Mob02";
        MaxHealth = 200.0f;
        Attack = 20.0f;
        Guard = 2.0f;
        CurrentHealth = MaxHealth;
        AttackSpeed = 1.0f;
        SkillCooltime = 0f;
        Job = 3;
    }
    private void Start()
    {
        //StageStat(int stage)
    }
    private void Update()
    {
        SkillCooltime += Time.deltaTime;
        if (SkillCooltime > 15)
        {
            Skill(Job);
            SkillCooltime -= 15f;
        }
    }
    private void LateUpdate()
    {
        Wars();
    }
}
