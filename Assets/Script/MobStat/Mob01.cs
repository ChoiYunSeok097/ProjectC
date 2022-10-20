using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Mob01 : EnemyManager
{
    
    private void Awake() 
    {
        var canvas = GameObject.Find("Canvas");
        hp = Instantiate<Image>(Hp);
        hp.transform.SetParent(canvas.transform);
        HpPosition();
        MobName = "Mob01";
        MaxHealth = 300.0f;
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
        HpPosition();
    }
}
