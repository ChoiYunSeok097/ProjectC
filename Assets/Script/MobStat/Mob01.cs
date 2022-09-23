using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob01 : EnemyManager
{
    
    private void Awake() 
    {
        MobName = "Mob01";
        MaxHealth = 200.0f;
        Attack = 20.0f;
        Guard = 5.0f;
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
        if(SkillCooltime > 15f)
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
