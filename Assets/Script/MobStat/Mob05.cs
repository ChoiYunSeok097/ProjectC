using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob05 : EnemyManager
{

    private void Awake()
    {
        MobName = "Mob05";
        MaxHealth = 450.0f;
        Attack = 45.0f;
        Guard = 12.0f;
        CurrentHealth = MaxHealth;
        AttackSpeed = 1.0f;
        SkillCooltime = 0f;
        Job = 0;
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
