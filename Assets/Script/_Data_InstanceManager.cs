using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Data_InstanceManager :  _Data_SingleTon<_Data_InstanceManager>
{
    public GameObject player, throwObjects;
    public List<GameObject> throwItems;

    public void instanceList() 
    {
        _Data_ResourseManager.instance.LoadResource();
        throwItems = new List<GameObject>();
    }

    public Sprite createImage(string _name)
    {
        Sprite resource = _Data_ResourseManager.instance.getResourceImage(_name);

        return resource;
    }

    // object pulling
    public void ThrowWeapon(GameObject _weapon, GameObject _enemy, _Data_Character _player)
    {
        GameObject newItem; 

        if (throwItems.Count == 0 || (newItem = throwItems.Find(o => o.transform.name.Equals(_weapon.transform.name + "(Clone)"))) == null)
        {
            GameObject weapon = GameObject.Instantiate<GameObject>(_weapon);
            _InGame_ThrowItem _throwItem = weapon.AddComponent<_InGame_ThrowItem>();
            _throwItem.character = _player;
            _throwItem.setEnemy(_enemy, _player.transform.position, _player.attack);
            weapon.transform.SetParent(throwObjects.transform);
        }
        else
        {
            newItem.SetActive(true);
            newItem.transform.position = _player.transform.position;

            _InGame_ThrowItem throwItem = newItem.GetComponent<_InGame_ThrowItem>();
            throwItem.character = _player;
            throwItem.setEnemy(_enemy, _player.transform.position, _player.attack);
            throwItems.Remove(newItem);
        }
    }

    // create Monster
    public GameObject createMob(Transform _parent, Vector3 _wavePos, Mob _mob)
    {
        GameObject mob = null;
        GameObject resource = _Data_ResourseManager.instance.getResourceMonster(_mob.name);

        if(resource != null)
        {   
            mob = GameObject.Instantiate<GameObject>(resource,_wavePos,Quaternion.identity);
            mob.transform.rotation = Quaternion.Euler(0,180,0);
            mob.transform.SetParent(_parent);
            mob.tag = "Enemy";
            //_Data_Enemy enemy = mob.AddComponent<_Data_Enemy>();
            _Data_Character enemy = mob.AddComponent<_Data_Character>();
            enemy.setStat(_mob);
        }

        return mob;
    }

    public void createWave(Transform MonsterParent, Transform [] _wavePos, Wave _wave)
    {
        createMob(MonsterParent, _wavePos[0].position, _wave.mob1);
        createMob(MonsterParent, _wavePos[1].position, _wave.mob2);
        createMob(MonsterParent, _wavePos[2].position, _wave.mob3);
        createMob(MonsterParent, _wavePos[3].position, _wave.mob4);
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
