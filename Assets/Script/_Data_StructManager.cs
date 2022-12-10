using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Character
{
    public Character(string _Name, float _star, float _job, bool _weapon1, bool _weapon2, float _Level, float _Exp,
                        float _hp, float _armor, float _attack, float _attackSpeed, float _attackRange, float _speed)
    {
        Name = _Name;
        star = _star;
        job = _job;
        weapon1 = _weapon1;
        Level = _Level;
        Exp = _Exp;
        hp = _hp;
        armor = _armor;
        attack = _attack;
        attackSpeed = _attackSpeed;
        attackRange = _attackRange;
        speed = _speed;
        weapon2 = _weapon2;
    }

    public string Name { set; get; }
    public float star { set; get; }
    public float job { set; get; }     // 0: warrior, 1:majision, 2:achor, 3:healer 
    public bool weapon1 { set; get; }
    public bool weapon2 { set; get; }
    public float Level { set; get; }
    public float Exp { set; get; }
    public float hp { set; get; }
    public float armor { set; get; }
    public float attack { set; get; }
    public float attackSpeed { set; get; }
    public float attackRange { set; get; }
    public float speed { set; get; }
}

public struct Wave
{
    public Mob mob1;
    public Mob mob2;
    public Mob mob3;
    public Mob mob4;
}

public struct Mob
{
    public string name;
    public float hp, armor, attack, attackSpeed, attackRange, speed, job;
    public bool canSkill, canCallTeam;
}
public struct Weapon
{
    public Weapon(string _Name, float _hp, float _armor, float _attack, string _charname)
    {
        WeaponName = _Name;
        WeaponHp = _hp;
        WeaponArmor = _armor;
        WeaponAttack = _attack;
        CharName = _charname;
    }
    public string WeaponName { set; get; }
    public float WeaponHp { set; get; }
    public float WeaponArmor { set; get; }
    public float WeaponAttack { set; get; }
    public string CharName { set; get; }
}


public class _Data_StructManager : MonoBehaviour
{

}
