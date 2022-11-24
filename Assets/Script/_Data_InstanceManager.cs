using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Data_InstanceManager :  _Data_SingleTon<_Data_InstanceManager>
{
    public GameObject player;

    public void instanceList() 
    {
        _Data_ResourseManager.instance.LoadResource();
    }

    public Sprite createImage(string _name)
    {
        Sprite resource = _Data_ResourseManager.instance.getResourceImage(_name);

        return resource;
    }

    // create Monster
    public GameObject createMob(Transform _parent, Transform _wavePos, Mob _mob)
    {
        GameObject mob = null;
        GameObject resource = _Data_ResourseManager.instance.getResourceMonster(_mob.name);

        if(resource != null)
        {   
            mob = GameObject.Instantiate<GameObject>(resource,_wavePos.position,Quaternion.identity);
            mob.transform.rotation = Quaternion.Euler(0,180,0);
            mob.transform.SetParent(_parent);
            mob.tag = "Enemy";
            _Data_Enemy enemy = mob.AddComponent<_Data_Enemy>();
            enemy.setStat(_mob);
        }

        return mob;
    }

    public void createWave(Transform MonsterParent, Transform [] _wavePos, Wave _wave)
    {
        createMob(MonsterParent, _wavePos[0], _wave.mob1);
        createMob(MonsterParent, _wavePos[1], _wave.mob2);
        createMob(MonsterParent, _wavePos[2], _wave.mob3);
        createMob(MonsterParent, _wavePos[3], _wave.mob4);
    }

    public void createWaves(Transform MonsterParent, List<Transform[]> _wavePosList, Wave [] _waves)
    {
        for(int i=0; i<_waves.Length; i++)
        {
            createWave(MonsterParent, _wavePosList[i], _waves[i]);
        }
    }

    // create Character
    public GameObject createChar(string _name, Transform _parent, Vector3 _pos, List<GameObject> charList)
    {
        GameObject Char = null;
        GameObject resource = _Data_ResourseManager.instance.getResourceChar(_name);
        //Debug.Log(resource);


        if(resource != null)
        {   
            Char = GameObject.Instantiate<GameObject>(resource,_pos,Quaternion.identity);
            _Data_CharManager.instance.setScript(_name, Char);  // add script
            Char.transform.SetParent(_parent);
            Char.tag = "Heroes";
            charList.Add(Char);
        }

        return Char;
    }

    // create Party
    public void createParty(Transform _parent, Transform [] _pos, List<GameObject> charList)
    {
        List<string>Chars = _Data_DataInput.instance.loadFile("/Party.csv");

        for (int i = 0; i < Chars.Count; i++)
        {
            createChar(Chars[i], _parent, _pos[i].position, charList);
        }
    }

}
