using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _UI_WeaponSlot : MonoBehaviour
{
    string fileName1 = "userWeapon.csv";
    string fileName2 = "userCharacter.csv";
    public Image weaponImage;
    public Image charImage;
    string charName;
    bool isEquip;

    private void Awake()
    {
        charImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        weaponImage = gameObject.GetComponent<Image>();
    }


    public void LoadSlot()
    {
        
        List<string> list = _Data_DataInput.instance.loadFile(fileName1);
        list.RemoveAt(0);

        for(int i=0; i<list.Count; i++)
        {
            string[] contents = list[i].Split(',');
            if (weaponImage.sprite.name == contents[0])
            {
                charName = contents[4];
                break;
            } 
        }

        list = _Data_DataInput.instance.loadFile(fileName2);
        list.RemoveAt(0);

        for (int i = 0; i < list.Count; i++)
        {
            string[] contents = list[i].Split(',');
            if(contents[0] == charName)
            {
                if (weaponImage.sprite.name == (charImage.sprite.name + "-1"))
                {        
                    if (contents[9] == "False")
                        isEquip = false;
                    else
                        isEquip = true;
                }
                if (weaponImage.sprite.name == (charImage.sprite.name + "-2"))
                {
                    if (contents[12] == "False")
                        isEquip = false;
                    else
                        isEquip = true;
                }
                break;
                
            }
            //Debug.Log(weaponImage.sprite.name);
            //Debug.Log(charImage.sprite.name + "-1");
        }

        if(isEquip == true)
        {
            weaponImage.color = Color.gray;
        }
        else
        {
            weaponImage.color = Color.white;
        }
        Debug.Log("ddd");
    }
}
