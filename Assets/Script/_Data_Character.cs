using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Data_Character : MonoBehaviour
{
    public Character stat;

    // stat
    int hp,armor,attack,attackSpeed,speed;

    public _Data_Character()
    {
        stat = new Character();
    }

    void Awake() 
    {      
        //stat = new Character();
        //Debug.Log(hp + armor);
    }

    public void setStat(Character _stat)
    {
        stat = _stat;
        hp = stat.hp;
        armor = stat.armor;
        attack = stat.attack;
        attackSpeed = stat.attackSpeed;
        speed = stat.speed;
    }

    public void print()
    {
        Debug.Log(hp);
    }

}
