using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ManagerWindow : MonoBehaviour, IPointerDownHandler
{
    GameObject StatusWindow;
    GameObject HeroWindow;
    GameObject WeaponWindow;
    GameObject LevelBar;
    string gold;
    int SpentGold;
    string useGold;
    void Awake()
    {
        StatusWindow = GameObject.Find("StatusWindow");
        HeroWindow = GameObject.Find("HeroWindow");
        WeaponWindow = GameObject.Find("WeaponWindow");
        LevelBar = GameObject.Find("LevelBar");
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
    }
    public void LevelUp()
    {
        SpentGold = int.Parse(useGold);
        int cash = int.Parse(gold);
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
            LevelBar.GetComponent<Image>().fillAmount = exp;
        }
    }
}
