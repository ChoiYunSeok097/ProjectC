using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Mob02 : EnemyManager
{

    private void Awake()
    {
        var canvas = GameObject.Find("Canvas");
        hp = Instantiate<Image>(Hp);
        hp.transform.SetParent(canvas.transform);
        HpPosition();
        MobName = "Mob02";
        MaxHealth = 200.0f;
        Attack = 20.0f;
        Guard = 2.0f;
        CurrentHealth = MaxHealth;
        AttackSpeed = 1.0f;
        SkillCooltime = 0f;
        Job = 3;
        AttackRange = 15f;
        pathFinder = GetComponent<NavMeshAgent>();
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
        NavMove();
        if (!canmove)
        {
            Wars();
        }
        else
        {
            time = 0;
        }
        HpPosition();
    }
}
