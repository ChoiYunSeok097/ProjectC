using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Data_ResourseManager : _Data_SingleTon<_Data_ResourseManager>
{
    string fileName = "Prefab/";
    List<GameObject> monsterList;
    List<GameObject> CharList;

    public void LoadResource() 
    {
        monsterList = new List<GameObject>();
        CharList = new List<GameObject>();
        
        GameObject[] Chars = Resources.LoadAll<GameObject>(fileName+"Character");
        GameObject[] Mobs = Resources.LoadAll<GameObject>(fileName+"Mob");

        foreach(GameObject one in Mobs)
        {
            monsterList.Add(one);
        }
        foreach(GameObject one in Chars)
        {
            CharList.Add(one);
        }
    }

    public GameObject getResourceMonster(string _name)
    {
        return monsterList.Find(o=>o.transform.name.Equals(_name));
    }
    public GameObject getResourceChar(string _name)
    {
        return CharList.Find(o=>o.transform.name.Equals(_name));
    }
    public void PrintResorces()
    {
        foreach(GameObject one in CharList)
        {
            Debug.Log(one.transform.name);
        }
    }
}
