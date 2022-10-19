using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MC01 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    
    private void Awake() 
    {
        var canvas = GameObject.Find("Canvas");
        hp = Instantiate<Image>(Hp);
        hp.transform.SetParent(canvas.transform);
        HpPosition();
        CharName = "MC01";
        Character_Lv = 1;
        Job = 0;
        Grade = 2;
        MaxHealth = 300.0f;
        CurrentHealth = MaxHealth;
        Attack = 30.0f;
        NeedExp = new int[60];
        Guard = 5.0f;
        AttackSpeed = 1.0f;
        AttackRange = 3f;
        pathFinder = GetComponent<NavMeshAgent>();
        LevelST();
    }

    private void Start() 
    {
        Weapon1(Weapon1);
        Weapon2(Weapon2);
    }

    private void Update()
    {
        LevelUp();
        if (Input.GetKeyDown(KeyCode.K))
        {
            Skill(Job);
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
    /*public void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.GetComponent<Animator>().GetBool("CanAttack"))
        {
            Damage = other.transform.root.GetComponent<EnemyManager>().Attack;
            Battle(Damage);
        }
        if (other.transform.tag == "Weapon")
        {
            Damage = other.transform.GetComponent<WeaponAttack>().Attack;
            Battle(Damage);
        }
    }*/
}
