using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob12 : EnemyManager
{

    private void Awake()
    {
        MobName = "Mob12";
        MaxHealth = 400.0f;
        Attack = 50.0f;
        Guard = 5.0f;
        CurrentHealth = MaxHealth;
        AttackSpeed = 1.0f;
        SkillCooltime = 0f;
        Job = 2;
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