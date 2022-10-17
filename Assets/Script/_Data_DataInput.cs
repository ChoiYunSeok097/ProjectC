using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class _Data_DataInput : _Data_SingleTon<_Data_DataInput>
{
    string path = Application.dataPath+"/Party.csv";


    public void saveFile(string _name, string [] _characters)
    {
        using(StreamWriter sw = new StreamWriter(path))
        {
            foreach(string one in _characters)
            {
                sw.WriteLine(one);
            }
            sw.Close();
        }
    }

    public List<string> loadFile(string _name)
    {
        List<string> characters = new List<string>();
        
        using(StreamReader sr = new StreamReader(path))
        {
            string line = string.Empty;
            while((line = sr.ReadLine()) != null)
            {
                characters.Add(line);
                line = string.Empty;
            }
            sr.Close();
        }
        return characters;
    }

}
