using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Data_ResourseManager : _Data_SingleTon<_Data_ResourseManager>
{
    string fileName = "Prefab/";
    List<GameObject> monsterList;
    List<GameObject> CharList;
    List<Sprite> imgList;

    public void LoadResource() 
    {
        monsterList = new List<GameObject>();
        CharList = new List<GameObject>();
        imgList = new List<Sprite>();
        
        GameObject[] Chars = Resources.LoadAll<GameObject>(fileName+"Character");
        GameObject[] Mobs = Resources.LoadAll<GameObject>(fileName+"Mob");
        Sprite[] images = Resources.LoadAll<Sprite>("Image");

        foreach(GameObject one in Mobs)
        {
            monsterList.Add(one);
        }
        foreach(GameObject one in Chars)
        {
            CharList.Add(one);
        }
        foreach(Sprite one in images)
        {
            imgList.Add(one);
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
    public Sprite getResourceImage(string _name)
    {
        return imgList.Find(o=>o.name.Equals(_name));
    }
    public void PrintResorces()
    {
        
    }
}