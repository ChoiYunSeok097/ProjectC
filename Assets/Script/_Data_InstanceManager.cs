using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Data_InstanceManager :  _Data_SingleTon<_Data_InstanceManager>
{
    public GameObject player;

    public void instanceList() 
    {
        _Data_ResourseManager.instance.LoadResource();
        
    }

    // create Monster
    public GameObject createMob(string _name, Transform _parent, Vector3 _pos)
    {
        GameObject Mob = null;
        GameObject resource = _Data_ResourseManager.instance.getResourceMonster(_name);

        if(resource != null)
        {   
            Mob = GameObject.Instantiate<GameObject>(resource,_pos,Quaternion.identity);
            Mob.transform.SetParent(_parent);
            Mob.tag = "Enemy";
        }

        return Mob;
    }

    public GameObject createChar(string _name, Transform _parent, Vector3 _pos)
    {
        GameObject Char = null;
        GameObject resource = _Data_ResourseManager.instance.getResourceChar(_name);
        Debug.Log(resource);
        
        if(resource != null)
        {   
            Char = GameObject.Instantiate<GameObject>(resource,_pos,Quaternion.identity);
            Char.transform.SetParent(_parent);
            Char.tag = "Char";
        }

        return Char;
    }




    /*
    public GameObject createMob(string _name, Transform _parent, Vector3 _pos)
    {
        GameObject monster;
        monster = monsters.Find(o=>o.transform.name.Equals(_name+"(Clone)"));

        // Object Pulling
        // null in nonActiveMonster
        if(monster == null)
        {
            
            GameObject resource = _Data_ResourseManager.instance.getResourceMonster(_name);
            monster = GameObject.Instantiate<GameObject>(resource,_pos,Quaternion.identity);

            Enemy enemy = monster.AddComponent<Enemy>();
            enemy.player = player;
            monster.transform.SetParent(_parent);
            monster.tag = "Enemy";

        }
        else
        {
            // active monster
            monster.transform.position = _pos;
            monster.SetActive(true);
            monsters.Remove(monster);
        }
        return monster;
    }

    */
    /*
    public void disabledMonster(GameObject monster)
    {
        monster.SetActive(false);
        monsters.Add(monster);
    }
    */
}
