using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _UI_characterList : MonoBehaviour
{
    public Image [] characterImg;
    public Text [] characterText;

    string fileName = "Party";

    void Awake()
    {
        setBlenk();
        loadCharacter();
    }

    // make img, text blenk
    void setBlenk()
    {
        foreach(Text str in characterText)
        {
            str.text = "";
        }
         foreach(Image img in characterImg)
        {
            img.sprite = Resources.Load<Sprite>("Image/Background");
        }
    }

    void loadCharacter()
    {
       List<string>list = _Data_DataInput.instance.loadFile(fileName);
       for(int i=0; i<characterImg.Length; i++)
       {
            //Debug.Log(list.Count);
            if(i>=list.Count)
            break;
            characterImg[i].sprite = Resources.Load<Sprite>("Image/" + list[i]);
            characterText[i].text = list[i];
       }
    }

}
