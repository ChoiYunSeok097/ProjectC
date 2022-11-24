using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Data_CharManager : _Data_SingleTon<_Data_CharManager>
{
    
    // return script
    public void setScript(string _name, GameObject Char)
    {
        // character's stat is loaded from file
        List<string> str = _Data_DataInput.instance.loadFile("/userCharacter.csv");

        foreach(string one in str)
        {
            string[] contents = one.Split(',');
            
            //find character in File
            if(_name == contents[0])
            {
                Character character = new Character();
                _Data_Character characterScript = Char.AddComponent<_Data_Character>();

                // input character state
                character.hp = float.Parse(contents[1]);
                character.armor = float.Parse(contents[2]);
                character.attack = float.Parse(contents[3]);
                character.attackSpeed = float.Parse(contents[4]);
                character.attackRange = float.Parse(contents[5]);
                character.speed = float.Parse(contents[6]);
                character.job = float.Parse(contents[7]);
                characterScript.setStat(character);
            }
            
        }
    }
    
}
