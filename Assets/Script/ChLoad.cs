using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChLoad : MonoBehaviour
{
    string Filename = "userCharacter.csv";
    List<string> ChList;
    
    public GameObject ChPrefab;
    public Transform [] charPos;
    public Transform parent;
    public void chloadlist()
    {
        ChList = _Data_DataInput.instance.loadFile(Filename);
        
        for(int i = 1; i < ChList.Count; i++)
        {
            
            string name = ChList[i].Split(',')[0];
            Sprite sprite = _Data_ResourseManager.instance.getResourceImage(name);
            GameObject.Instantiate(ChPrefab, charPos[i-1]).GetComponent<Image>().sprite = sprite;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        chloadlist();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
