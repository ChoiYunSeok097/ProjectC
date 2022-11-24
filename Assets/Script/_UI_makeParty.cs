using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _UI_makeParty : MonoBehaviour
{
    // Start is called before the first frame update
    string fileName = "Party.csv";
    List<GameObject> charList;
    public Transform [] charPos;
    public Transform parent;

    void Start()
    {
        charList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadCharacter()
    {
        //List<string> list = _Data_DataInput.instance.loadFile(fileName);

        //_Data_InstanceManager.instance.createParty(parent, charPos,charList);

       // foreach(string one in list)
        //_Data_InstanceManager.instance.createImage(one);
    }
}
