using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class _UI_makeParty : MonoBehaviour
{
    public Text [] nametext;
    string fileName = "Party.csv";
    List<string> PartyList;
    public Transform [] charPos;
    public Transform parent;
    public Transform [] PartySlot; 
    public void LoadParty()
    {
        DesParty();
        PartyList = _Data_DataInput.instance.loadFile(fileName);
        for (int i = 0; i < PartyList.Count; i++)
        {
            GameObject Char;
            Char = _Data_InstanceManager.instance.createChar(PartyList[i], parent, charPos[i].position, null);
            if (Char == null)
            {
                nametext[i].text = "";
                continue;
            }
            Destroy(Char.GetComponent<_Data_Character>());
            Char.GetComponent<Rigidbody>().useGravity = false;
            Char.transform.rotation = Quaternion.Euler(0,180,0);
            Char.transform.localScale = new Vector3(200,200,200);

            nametext[i].text = PartyList[i];
        }
        
    }
    public void SaveParty()
    {
        string [] name = new string[PartySlot.Length];
        for(int i = 0; i < PartySlot.Length; i++)
        {
            if (PartySlot[i].transform.childCount == 0)
            {
                continue;
            }
            name[i] = PartySlot[i].GetChild(0).GetComponent<Image>().sprite.name;
        
        }
        _Data_DataInput.instance.saveFile("Party.csv",name);
        
    }
    public void DesParty()
    {
        for(int i = 4; i < parent.childCount; i++)
        {
            if (parent.GetChild(i) == null)
            {
                break;
            }
            Destroy(parent.GetChild(i).gameObject);
            
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
