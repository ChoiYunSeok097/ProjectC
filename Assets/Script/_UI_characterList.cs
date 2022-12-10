using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class _UI_characterList : MonoBehaviour, IPointerDownHandler
{
    public Image[] characterImg;
    public Text[] characterText;
    GameObject herosprite;
    string fileName = "Party.csv";
    void Awake()
    {
        herosprite = GameObject.Find("SoundObject");
        setBlenk();
        loadCharacter();
    }
    // make img, text blenk
    void setBlenk()
    {
        foreach (Text str in characterText)
        {
            str.text = "";
        }
        foreach (Image img in characterImg)
        {
            //img.sprite = Resources.Load<Sprite>("Image/Background");
        }
    }

    void loadCharacter()
    {
        List<string> list = _Data_DataInput.instance.loadFile(fileName);
        for (int i = 0; i < characterImg.Length; i++)
        {
            if (i >= list.Count)
                break;
            characterImg[i].sprite = Resources.Load<Sprite>("Image/" + list[i]);
            characterText[i].text = list[i];
        }
    }
    public void OnPointerDown(PointerEventData _eventData)
    {
        GameObject ui = _eventData.pointerEnter;
        if (characterImg != null && ui.name == "Character")
        {
            Debug.Log(ui.GetComponent<Image>().sprite.name);
            herosprite.GetComponent<SoundObject>().sprite = ui.GetComponent<Image>().sprite;
            SceneManager.LoadScene("HeroManager");
        }
    }
}
