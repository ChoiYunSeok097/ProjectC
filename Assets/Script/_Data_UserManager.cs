using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class _Data_UserManager : MonoBehaviour
{
    public Text goldText;
    string Name,level,gold;

    private void Awake()
    {
        getUserdata();
    }

    public void getUserdata()
    {
        List<string> contents = _Data_DataInput.instance.loadFile("userData.csv");
        Name = contents[1].Split(',')[0];
        level = contents[1].Split(',')[1];
        gold = contents[1].Split(',')[2];

        if (goldText != null)
        {
            gold = contents[1].Split(',')[2];
            goldText.text = gold;
        }
    }

    public void setUserdata()
    {
        List<string> contents = _Data_DataInput.instance.loadFile("userData.csv");
        if (goldText != null)
        {
            gold = goldText.text;
            contents[1] = name + ',' + level + ',' + gold;
            using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + "userData.csv"))
            {
                foreach (string one in contents)
                {
                    sw.WriteLine(one);
                    print(one);
                    print(contents[1]);
                }
                sw.Close();
            }
        }
    }

    public void addUserdata(int _gold)
    {
        List<string> contents = _Data_DataInput.instance.loadFile("userData.csv");
        Name = contents[1].Split(',')[0];
        level = contents[1].Split(',')[1];
        gold = contents[1].Split(',')[2];

        
        gold += _gold;
        print(gold);
        contents[1] = name + ',' + level + ',' + gold;
        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + "userData.csv"))
        {
            foreach (string one in contents)
            {
                sw.WriteLine(one);
                print(one);
                print(contents[1]);
            }
            sw.Close();
        }
        
    }
}
