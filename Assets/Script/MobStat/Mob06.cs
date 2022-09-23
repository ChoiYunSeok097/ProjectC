using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob06 : EnemyManager
{

    private void Awake()
    {
        MobName = "Mob06";
        MaxHealth = 300.0f;
        Attack = 34.0f;
        Guard = 4.0f;
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
        if (SkillCooltime > 15f)
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
