using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob01 : EnemyManager
{
    
    private void Awake() 
    {
        MobName = "Mob01";
        MaxHealth = 500.0f;
        Attack = 20.0f;
        Guard = 5.0f;
        CurrentHealth = MaxHealth;
        AttackSpeed = 1.0f;
        SkillCooltime = 0f;
        Job = 0;
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
        if(SkillCooltime > 15f)
        {
            Skill(Job);
            SkillCooltime -= 15f;
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.GetComponent<Animator>().GetBool("CanAttack"))
        {
            Damage = other.transform.root.GetComponent<CharacterManager>().Attack;
            Battle(Damage);
        }
        if(other.transform.tag == "Weapon")
        {
            Damage = other.transform.GetComponent<WeaponAttack>().Attack;
            Battle(Damage);
        }
    }*/
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
