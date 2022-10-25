using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Character
{
    public Character(string _Name, int _star,int _job, bool _weapon, int _Level, int _Exp,
                        int _hp, int _armor,int _attack, int _attackSpeed, int _speed)
    {
        Name = _Name;
        star = _star;
        job = _job;
        weapon = _weapon;
        Level = _Level;
        Exp = _Exp;
        hp = _hp;
        armor = _armor;
        attack = _attack;
        attackSpeed = _attackSpeed;
        speed = _speed;
    }

    public string Name { set; get; }
    public int star { set; get; }
    public int job{ set; get; }     // 0: warrior, 1:majision, 2:achor, 3:healer 
    public bool weapon{ set; get; }
    public int Level{ set; get; }
    public int Exp{ set; get; }
    public int hp { set; get; }
    public int armor{ set ;get;}
    public int attack{ set ;get;}
    public int attackSpeed{ set ;get;}
    public int speed{ set ;get;}
}



public class _Data_CharManager : _Data_SingleTon<_Data_CharManager>
{
    
    // return script
    public void setScript(string _name, GameObject Char)
    {
        List<string> str = _Data_DataInput.instance.loadFile("/userCharacter.csv");

        foreach(string one in str)
        {
            string[] contents = one.Split(',');
            
            //find character in userFile
            if(_name == contents[0])
            {
                Character character = new Character();
                _Data_Character characterScript = Char.AddComponent<_Data_Character>();

                // input character state
                character.hp = int.Parse(contents[1]);
                character.armor = int.Parse(contents[2]);
                character.attack = int.Parse(contents[3]);
                character.attackSpeed = int.Parse(contents[4]);
                character.speed = int.Parse(contents[5]);
                characterScript.setStat(character);
            }
            
        }
    }
}
