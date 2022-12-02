using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ManagerWindow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    Character stat;
    public void setScript(string _name)
    {
        // character's stat is loaded from file
        List<string> str = _Data_DataInput.instance.loadFile("/userCharacter.csv");

        foreach (string one in str)
        {
            string[] contents = one.Split(',');

            //find character in File
            if (_name == contents[0])
            {
                stat = new Character();
                // input character state
                stat.Level = level;
                stat.hp = float.Parse(contents[1]) + level * 2;
                stat.armor = float.Parse(contents[2]) + level * 0.2f;
                stat.attack = float.Parse(contents[3]) + level * 0.5f;
                stat.attackSpeed = float.Parse(contents[4]);
                stat.attackRange = float.Parse(contents[5]);
                stat.speed = float.Parse(contents[6]);
                stat.job = float.Parse(contents[7]);
            }

        }
    }
    GameObject StatusWindow;
    GameObject HeroWindow;
    GameObject WeaponWindow;
    GameObject LevelBar;
    GameObject HeroLevel;
    public GameObject selectedSlot;
    public Text HeroName;
    public Image CharacterSlot;
    public Text Hpstat;
    public Text AttackStat;
    public Text DefStat;
    string herolevel;
    int level = 1;
    string gold;
    int SpentGold;
    string useGold;
    void Awake()
    {
        StatusWindow = GameObject.Find("StatusWindow");
        HeroWindow = GameObject.Find("HeroWindow");
        WeaponWindow = GameObject.Find("WeaponWindow");
        LevelBar = GameObject.Find("LevelBar");
        HeroLevel = GameObject.Find("HeroLevel");
        herolevel = HeroLevel.GetComponent<Text>().text;
        gold = GameObject.Find("Cash").GetComponent<Text>().text;
        useGold = GameObject.Find("Spent").GetComponent<Text>().text;
    }
    // Start is called before the first frame update
    void Start()
    {
        StatusWindow.SetActive(false);
        HeroWindow.SetActive(true);
        WeaponWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StatusOpen()
    {
        if(StatusWindow.activeSelf == false)
        {
            StatusWindow.SetActive(true);
            HeroWindow.SetActive(false);
            WeaponWindow.SetActive(false);
        }
    }
    public void HeroesOpen()
    {
        if (HeroWindow.activeSelf == false)
        {
            StatusWindow.SetActive(false);
            HeroWindow.SetActive(true);
            WeaponWindow.SetActive(false);
        }
    }
    public void WeaponesOpen()
    {
        if (WeaponWindow.activeSelf == false)
        {
            StatusWindow.SetActive(false);
            HeroWindow.SetActive(false);
            WeaponWindow.SetActive(true);
        }
    }
    public void OnPointerDown(PointerEventData _eventData)
    {
        GameObject ui = _eventData.pointerEnter;
        Debug.Log(ui.name);
        if (ui.name == "Character")
        {
            if (ui.GetComponent<Image>().sprite.name == "SelectedHero")
            {
                StatusOpen();
            }
        }
        else if(ui.name == "Weapon1")
        {
            if (ui.GetComponent<Image>().sprite.name == "SelectedWeapon1")
            {
                WeaponesOpen();
            }
        }
        else if (ui.name == "Weapon2")
        {
            if (ui.GetComponent<Image>().sprite.name == "SelectedWeapon2")
            {
                WeaponesOpen();
            }
        }
        if(ui.name == "HeroSlot")
        {
            if(ui.GetComponent<Image>().sprite != null)
            {
                selectedSlot.GetComponent<Image>().sprite = ui.GetComponent<Image>().sprite;
                selectedSlot.SetActive(true);
                selectedSlot.transform.position = _eventData.position;
            } 
        }
    }
    public void OnPointerUp(PointerEventData _eventData)
    {
        GameObject ui = _eventData.pointerEnter;
        Debug.Log(ui.name);
        if (selectedSlot.activeSelf == true)
        {
            if(ui.name == "Character")
            {
                ui.GetComponent<Image>().sprite = selectedSlot.GetComponent<Image>().sprite;
                StatUpdate();
            }
            selectedSlot.SetActive(false);
        }
        
    }
    public void OnDrag(PointerEventData _eventData)
    {
        if(selectedSlot.activeSelf == true)
        {
            selectedSlot.transform.position = _eventData.position;
        }
    }
    public void LevelUp()
    {
        SpentGold = int.Parse(useGold);
        int cash = int.Parse(gold);
        if(cash >= SpentGold)
        {
            cash -= SpentGold;
            SpentGold += 100;
            useGold = SpentGold.ToString();
            gold = cash.ToString();
            GameObject.Find("Cash").GetComponent<Text>().text = gold;
            GameObject.Find("Spent").GetComponent<Text>().text = useGold;
            float exp = LevelBar.GetComponent<Image>().fillAmount;
            exp += 0.8f;
            LevelBar.GetComponent<Image>().fillAmount = exp;
            if (exp >= 1f)
            {
                exp -= 1f;
                level++;
                herolevel = "Lv." + level;
                HeroLevel.GetComponent<Text>().text = herolevel;
                LevelBar.GetComponent<Image>().fillAmount = exp;
                StatUpdate();
                Debug.Log(level);
            }
        }
        else if(cash < SpentGold)
        {
            Debug.Log("돈이 부족합니다");
        }
    }
    void StatUpdate()
    {
        if (CharacterSlot.sprite.name != "SelectedHero" && CharacterSlot.sprite != null)
        {
            setScript(CharacterSlot.sprite.name);
            Hpstat.text = "체력 : " + stat.hp.ToString();
            AttackStat.text = "공격력 : " + stat.attack.ToString();
            DefStat.text = "방어력 : " + stat.armor.ToString();
            HeroName.text = CharacterSlot.sprite.name;
        }
    }
}
