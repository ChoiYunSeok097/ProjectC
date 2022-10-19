using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MC02 : CharacterManager
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    private void Awake()
    {
        var canvas = GameObject.Find("Canvas");
        hp = Instantiate<Image>(Hp);
        hp.transform.SetParent(canvas.transform);
        HpPosition();
        CharName = "MC02";
        Character_Lv = 1;
        Job = 0;
        Grade = 1;
        MaxHealth = 200.0f;
        CurrentHealth = MaxHealth;
        Attack = 20.0f;
        NeedExp = new int[50];
        Guard = 3.0f;
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
