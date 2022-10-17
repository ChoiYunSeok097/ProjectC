using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class _DataUser : MonoBehaviour
{
    public static _DataUser DataUser;

    void Awake() 
    {
        if(DataUser == null)
            DataUser = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void test()
    {
        List<string> str = new List<string>();
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Char");

        foreach(GameObject one in obj)
        {
            str.Add(one.transform.name);
        }

        //SaveParty(str);
        LoadParty();
    }

    //save pary infomation
    void SaveParty(List<string> party)
    {
        string path = Application.dataPath+"/Party.csv";
        using(StreamWriter sw = new StreamWriter(path))
        {
            foreach(string one in party)
            {
                sw.WriteLine(one);
            }
            sw.Close();
        }
        
    }

    //load pary infomation
    List<string> LoadParty()
    {
        string path = Application.dataPath+"/Party.csv";
        List<string>party = new List<string>();
        using(StreamReader sr = new StreamReader(path))
        {
            string line = string.Empty;
            while((line = sr.ReadLine()) != null)
            {
                party.Add(line);
                //Debug.Log(line);
                line = string.Empty;
            }
            sr.Close();
        }
        return party;
    }


}
