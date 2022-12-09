using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _UI_makeParty : MonoBehaviour
{
    // Start is called before the first frame update
    
    string fileName = "Party.csv";
    List<string> PartyList;
    public Transform [] charPos;
    public Transform parent;

    public void LoadParty()
    {

        PartyList = _Data_DataInput.instance.loadFile(fileName);
        for (int i = 0; i < PartyList.Count; i++)
        {
            GameObject Char;
            Char = _Data_InstanceManager.instance.createChar(PartyList[i], parent, charPos[i].position, null);
            Destroy(Char.GetComponent<_Data_Character>());
            Char.GetComponent<Rigidbody>().useGravity = false;
            Char.transform.rotation = Quaternion.Euler(0,180,0);
            Char.transform.localScale = new Vector3(200,200,200);

        }
        
    }
    void Start()
    {
        PartyList = new List<string>();
        _Data_InstanceManager.instance.instanceList();
        LoadParty();
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
