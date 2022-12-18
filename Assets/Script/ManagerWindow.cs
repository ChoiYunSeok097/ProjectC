using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.SceneManagement;

public class ManagerWindow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public _Data_UserManager user;

    Character stat;
    Weapon Weapon1stat;
    Weapon Weapon2stat;
    string[] stats;
    List<string> strs;
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
                stat.hp = float.Parse(contents[1]);
                stat.armor = float.Parse(contents[2]);
                stat.attack = float.Parse(contents[3]);
                stat.attackSpeed = float.Parse(contents[4]);
                stat.attackRange = float.Parse(contents[5]);
                stat.speed = float.Parse(contents[6]);
                stat.job = int.Parse(contents[7]);
                stat.weapon1 = bool.Parse(contents[9]);
                stat.Level = float.Parse(contents[10]);
                stat.Exp = float.Parse(contents[11]);
                stat.weapon2 = bool.Parse(contents[12]);
                level = stat.Level;
                exp = stat.Exp;
                LevelBar.GetComponent<Image>().fillAmount = exp;
            }
        }
        
    }
    public void Weapon1setScript(string _name)
    {
        List<string> str = _Data_DataInput.instance.loadFile("/userWeapon.csv");

        foreach (string one in str)
        {
            string[] contents = one.Split(',');
            //find Weapon in File
            if (_name == contents[0])
            {
                Weapon1stat = new Weapon();
                // input weapon state
                Weapon1stat.WeaponName = contents[0];
                Weapon1stat.WeaponHp = float.Parse(contents[1]);
                Weapon1stat.WeaponArmor = float.Parse(contents[2]);
                Weapon1stat.WeaponAttack = float.Parse(contents[3]);
                Weapon1stat.CharName = contents[4];
            }
        }
    }
    public void Weapon2setScript(string _name)
    {
        List<string> str = _Data_DataInput.instance.loadFile("/userWeapon.csv");

        foreach (string one in str)
        {
            string[] contents = one.Split(',');
            //find weapon in File
            if (_name == contents[0])
            {
                Weapon2stat = new Weapon();
                // input weapon state
                Weapon2stat.WeaponName = contents[0];
                Weapon2stat.WeaponHp = float.Parse(contents[1]);
                Weapon2stat.WeaponArmor = float.Parse(contents[2]);
                Weapon2stat.WeaponAttack = float.Parse(contents[3]);
                Weapon2stat.CharName = contents[4];
            }
        }
    }
    public void loadCharacter(string _name)
    {
        List<string> list = _Data_DataInput.instance.loadFile(_name);
        list.RemoveAt(0);
        for (int i = 0; i < list.Count; i++)
        {
            string [] contents = list[i].Split(',');
            characterImg[i].sprite = Resources.Load<Sprite>("Image/" + contents[0]);
        }
        for (int i = 0; i < characterImg.Length; i++)
        {
            if (characterImg[i].sprite == null)
            {
                characterImg[i].gameObject.SetActive(false);
            }
        }
    }
    SoundObject sprite;
    public GameObject StatusWindow;
    public GameObject HeroWindow;
    public GameObject WeaponWindow;
    public GameObject LevelBar;
    public Text HeroLevel;
    public Image[] characterImg;
    public GameObject selectedSlot;
    public Text HeroName;
    public Image CharacterSlot;
    public Image WeaponSlot1;
    public Image WeaponSlot2;
    public Image Job;
    public Image AttackType;
    public Text Hpstat;
    public Text AttackStat;
    public Text DefStat;
    float exp;
    string uiname;
    string herolevel;
    float level;
    string gold;
    int SpentGold;
    string useGold;
    string sname;
    string shp;
    string sarmor;
    string sattack;
    string sattackSpeed;
    string sattackRange;
    string sspeed;
    string sjob;
    string sstar;
    string sweapon1;
    string slevel;
    string sexp;
    string sweapon2;
    void Awake()
    {
        loadCharacter("userCharacter.csv");
        sprite = GameObject.Find("SoundObject").GetComponent<SoundObject>();
        herolevel = HeroLevel.text;
        gold = GameObject.Find("Cash").GetComponent<Text>().text;
        useGold = GameObject.Find("Spent").GetComponent<Text>().text;
        stats = new string[13];
    }
    // Start is called before the first frame update
    void Start()
    {
        StatusWindow.SetActive(true);
        HeroWindow.SetActive(false);
        WeaponWindow.SetActive(false);
        CharacterSlot.sprite = sprite.sprite;
        setScript(CharacterSlot.sprite.name);
        StatUpdate();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(stat.weapon1);
            Debug.Log(stat.weapon2);
        }

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

            WeaponWindow.GetComponent<_UI_WeaponWindow>().loadSlot();
        }
    }
    public void OnPointerDown(PointerEventData _eventData)
    {
        GameObject ui = _eventData.pointerEnter;
        if (ui.name == "Character")
        {
            if (ui.GetComponent<Image>().sprite.name == "SelectedHero")
            {
                HeroesOpen();
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
        if(ui.name == "HeroSlot" || ui.name == "WeaponSlot")
        {
            if(ui.GetComponent<Image>().sprite != null)
            {
                
                uiname = ui.name;
                selectedSlot.GetComponent<Image>().sprite = ui.GetComponent<Image>().sprite;
                selectedSlot.SetActive(true);
                selectedSlot.transform.position = _eventData.position;
            } 
        }
    }
    public void OnPointerUp(PointerEventData _eventData)
    {
        GameObject ui = _eventData.pointerEnter;
        if (selectedSlot.activeSelf == true)
        {
            if(ui.name == "Character" && uiname == "HeroSlot")
            {
                ui.GetComponent<Image>().sprite = selectedSlot.GetComponent<Image>().sprite;
                setScript(CharacterSlot.sprite.name);
            }
            if (ui.name == "Weapon1" && uiname == "WeaponSlot" && WeaponSlot1.sprite.name == "SelectedWeapon1")
            {

                if (selectedSlot.GetComponent<Image>().sprite.name == CharacterSlot.GetComponent<Image>().sprite.name + "-1")
                {
                    ui.GetComponent<Image>().sprite = selectedSlot.GetComponent<Image>().sprite;
                    Weapon1setScript(WeaponSlot1.sprite.name);
                    stat.weapon1 = true;
                    Weapon1Update();
                }
            }
            if (ui.name == "Weapon2" && uiname == "WeaponSlot" && WeaponSlot2.sprite.name == "SelectedWeapon2")
            {
                if (selectedSlot.GetComponent<Image>().sprite.name == CharacterSlot.GetComponent<Image>().sprite.name + "-2")
                {
                    ui.GetComponent<Image>().sprite = selectedSlot.GetComponent<Image>().sprite;
                    Weapon2setScript(WeaponSlot2.sprite.name);
                    stat.weapon2 = true;
                    Weapon2Update();
                }
            }
            //StatusOpen();
            StatUpdate();
            selectedSlot.SetActive(false);
            WeaponWindow.GetComponent<_UI_WeaponWindow>().loadSlot();
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
            SpentGold += 50;
            useGold = SpentGold.ToString();
            gold = cash.ToString();
            GameObject.Find("Cash").GetComponent<Text>().text = gold;
            GameObject.Find("Spent").GetComponent<Text>().text = useGold;
            exp += 0.8f;
            stat.Exp = exp;
            LevelBar.GetComponent<Image>().fillAmount = exp;
            if (exp >= 1.0f)
            {
                level++;
                exp -= 1.0f;
                LevelBar.GetComponent<Image>().fillAmount = exp;
                stat.Level = level;
                LevelUpStat();
                stat.Exp = exp;
                StatUpdate();
            }
            StatUpdate();
        }
        else if(cash < SpentGold)
        {
            Debug.Log("돈이 부족합니다");
        }

        if(user != null)
        {
            user.setUserdata();
        }

    }
    void StatUpdate()
    {
        if (CharacterSlot.sprite.name != "SelectedHero" && CharacterSlot.sprite != null)
        {
            StatText();
            SaveButton();
            HeroesType();
        }
    }
    void Weapon1Update()
    {
        if ((Weapon1stat.WeaponName == WeaponSlot1.sprite.name) && (CharacterSlot.sprite.name == Weapon1stat.CharName))
        {
            stat.hp += Weapon1stat.WeaponHp;
            stat.attack += Weapon1stat.WeaponAttack;
            stat.armor += Weapon1stat.WeaponArmor;
            StatText();
            
        }
        else if ((Weapon1stat.WeaponName == WeaponSlot1.sprite.name) && (CharacterSlot.sprite.name != Weapon1stat.CharName))
        {
            //stat.weapon1 = false;
        }
    }
    void Weapon2Update()
    {
        if ((Weapon2stat.WeaponName == WeaponSlot2.sprite.name) && (CharacterSlot.sprite.name == Weapon2stat.CharName))
        {
            stat.hp += Weapon2stat.WeaponHp;
            stat.attack += Weapon2stat.WeaponAttack;
            stat.armor += Weapon2stat.WeaponArmor;
            StatText();
            
        }
        else if ((Weapon2stat.WeaponName == WeaponSlot2.sprite.name) && (CharacterSlot.sprite.name != Weapon2stat.CharName))
        {
            //stat.weapon2 = false;
        }
    }
    void StatText()
    {
        //setScript(CharacterSlot.sprite.name);
        HeroName.text = CharacterSlot.sprite.name;
        stat.Name = CharacterSlot.sprite.name;
        herolevel = "Lv." + level;
        HeroLevel.text = herolevel;
        Hpstat.text = "체력 : " + (stat.hp).ToString();
        AttackStat.text = "공격력 : " + (stat.attack).ToString();
        DefStat.text = "방어력 : " + (stat.armor).ToString();
        if (stat.weapon1 && (stat.weapon2 == false))
        {
            WeaponSlot1.sprite = Resources.Load("Image/"+stat.Name.ToString()+"-1", typeof(Sprite)) as Sprite;
            WeaponSlot2.sprite = Resources.Load("Image/SelectedWeapon2", typeof(Sprite)) as Sprite; 
            WeaponSlot1.GetComponentInChildren<Text>().text = WeaponSlot1.sprite.name;
        }
        else if(stat.weapon2 && (stat.weapon1 == false))
        {
            WeaponSlot1.sprite = Resources.Load("Image/SelectedWeapon1", typeof(Sprite)) as Sprite;
            WeaponSlot2.sprite = Resources.Load("Image/"+stat.Name.ToString()+"-2", typeof(Sprite)) as Sprite;
            WeaponSlot2.GetComponentInChildren<Text>().text = WeaponSlot2.sprite.name;
        }
        else if(stat.weapon1 && stat.weapon2)
        {
            WeaponSlot1.sprite = Resources.Load("Image/"+stat.Name.ToString()+"-1", typeof(Sprite)) as Sprite;
            WeaponSlot2.sprite = Resources.Load("Image/"+stat.Name.ToString()+"-2", typeof(Sprite)) as Sprite;
            WeaponSlot1.GetComponentInChildren<Text>().text = WeaponSlot1.sprite.name;
            WeaponSlot2.GetComponentInChildren<Text>().text = WeaponSlot2.sprite.name;
        }
        else
        {
            WeaponSlot1.sprite = Resources.Load("Image/SelectedWeapon1", typeof(Sprite)) as Sprite;
            WeaponSlot2.sprite = Resources.Load("Image/SelectedWeapon2", typeof(Sprite)) as Sprite;
            WeaponSlot1.GetComponentInChildren<Text>().text = "Select";
            WeaponSlot2.GetComponentInChildren<Text>().text = "Select";
        }
    }
    void HeroesType()
    {
        switch (stat.job)
        {
            case 0:
                Job.sprite = Resources.Load("Image/Shield" ,typeof(Sprite)) as Sprite;
                AttackType.sprite = Resources.Load("Image/Sword", typeof(Sprite)) as Sprite;
                break;
            case 1:
                Job.sprite = Resources.Load("Image/Bow", typeof(Sprite)) as Sprite;
                AttackType.sprite = Resources.Load("Image/Arrow", typeof(Sprite)) as Sprite;
                break;
            case 2:
                Job.sprite = Resources.Load("Image/Staff", typeof(Sprite)) as Sprite;
                AttackType.sprite = Resources.Load("Image/Magic", typeof(Sprite)) as Sprite;
                break;
        }
    }
    void setStat(Character _stat)
    {
        stat = _stat;
        sname = stat.Name;
        shp = stat.hp.ToString();
        sarmor = stat.armor.ToString();
        sattack = stat.attack.ToString();
        sattackSpeed = stat.attackSpeed.ToString();
        sattackRange = stat.attackRange.ToString();
        sspeed = stat.speed.ToString();
        sjob = stat.job.ToString();
        sstar = stat.star.ToString();
        sweapon1 = stat.weapon1.ToString();
        slevel = stat.Level.ToString();
        sexp = stat.Exp.ToString();
        sweapon2 = stat.weapon2.ToString();
        stats[0] = sname;
        stats[1] = shp;
        stats[2] = sarmor;
        stats[3] = sattack;
        stats[4] = sattackSpeed;
        stats[5] = sattackRange;
        stats[6] = sspeed;
        stats[7] = sjob;
        stats[8] = sstar;
        stats[9] = sweapon1;
        stats[10] = slevel;
        stats[11] = sexp;
        stats[12] = sweapon2;
    }
    public void SaveScript(string _name)
    {
        // character's stat is loaded from file
        strs = _Data_DataInput.instance.loadFile("/userCharacter.csv");
        for (int i = 0; i < strs.Count; i++)
        {
            string[] contents = strs[i].Split(',');
            if (_name == contents[0])
            {
                string line = string.Empty;
                for (int k = 0; k < stats.Length; k++)
                {
                    line += stats[k] + ",";
                }
                strs[i] = line;
            }
        }
        csvUpdate();
    }
    void csvUpdate()
    {
        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + "/userCharacter.csv"))
        {
            for(int i =0; i < strs.Count; i++)
            {
                sw.WriteLine(strs[i]);
            }
            sw.Close();
        }
    }
    void LevelUpStat()
    {
        switch (stat.job)
        {
            case 0:
                stat.hp += 2f;
                stat.armor += 0.2f;
                stat.attack += 0.5f;
                break;
            case 1:
                stat.hp += 1f;
                stat.armor += 0.1f;
                stat.attack += 1f;
                break;
            case 2:
                stat.hp += 1f;
                stat.armor += 0.1f;
                stat.attack += 1f;
                break;
        }
        
    }
    public void Backspace()
    {
        SceneManager.LoadScene("MainLobby");
    }
    public void SaveButton()
    {
        setStat(stat);
        SaveScript(stats[0]);
    }
    public void Weapon1Close()
    {
        if (stat.weapon1)
        {
            Weapon1setScript(WeaponSlot1.sprite.name);
            WeaponSlot1.sprite = Resources.Load("Image/SelectedWeapon1", typeof(Sprite)) as Sprite;
            WeaponSlot1.GetComponentInChildren<Text>().text = "Select";
            stat.weapon1 = false;
            stat.hp -= Weapon1stat.WeaponHp;
            stat.attack -= Weapon1stat.WeaponAttack;
            stat.armor -= Weapon1stat.WeaponArmor;
            Hpstat.text = "체력 : " + stat.hp.ToString();
            AttackStat.text = "공격력 : " + stat.attack.ToString();
            DefStat.text = "방어력 : " + stat.armor.ToString();
        }
        SaveButton();
        WeaponWindow.GetComponent<_UI_WeaponWindow>().loadSlot();
    }
    public void Weapon2Close()
    {
        if (stat.weapon2)
        {
            Weapon2setScript(WeaponSlot2.sprite.name);
            WeaponSlot2.sprite = Resources.Load("Image/SelectedWeapon2", typeof(Sprite)) as Sprite;
            WeaponSlot2.GetComponentInChildren<Text>().text = "Select";
            stat.weapon2 = false;
            stat.hp -= Weapon2stat.WeaponHp;
            stat.attack -= Weapon2stat.WeaponAttack;
            stat.armor -= Weapon2stat.WeaponArmor;
            Hpstat.text = "체력 : " + stat.hp.ToString();
            AttackStat.text = "공격력 : " + stat.attack.ToString();
            DefStat.text = "방어력 : " + stat.armor.ToString();
        }
        SaveButton();
        WeaponWindow.GetComponent<_UI_WeaponWindow>().loadSlot();
    }

    
}
