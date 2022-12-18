using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class _Data_StageManager : MonoBehaviour
{
    public Text text;

    public static Wave[] waves;
    public static Mob boss;
    public static int gold = 0;

    private void Awake()
    {
        if(text != null)
        {
            text.text = gold.ToString();
        }
    }

    public void Charactors_down()
    {
        SceneManager.LoadScene("HeroMenu");
    }
    public void StageSelect_down()
    {
        SceneManager.LoadScene("StageSelect");
    }
    public void Charactors_Party_down()
    {
        SceneManager.LoadScene("UI_Party");
    }
    public void InGameStage()
    {
        SceneManager.LoadScene("New Battle");
    }
    public void Backspace()
    {
        SceneManager.LoadScene("MainLobby");
    }

    public void outStage()
    {
        SceneManager.LoadScene("MainLobby");
    }

    public void Stage_1()
    {
        // reward
        gold = 300;
        

        // three waves
        waves = new Wave[3];

        // mob1 stat
        Mob mob1 = new Mob();
        
        mob1.name = "Mob01";
        mob1.hp = 14;
        mob1.armor = 1;
        mob1.attack = 2;
        mob1.attackSpeed = 0.5f;
        mob1.attackRange = 1f;
        mob1.speed = 1;

        // input mob in waves
        for( int i =0; i<waves.Length; i++)
        {
            waves[i].mob1 = mob1;
            waves[i].mob2 = mob1;
            waves[i].mob3 = mob1;
            waves[i].mob4 = mob1;
        }

        // go to InGame
        InGameStage();
    }

    public void Stage_2()
    {
        // reward
        gold = 450;
        

        // three waves
        waves = new Wave[3];

        // mob1 stat
        Mob mob1 = new Mob();
        Mob mob2 = new Mob();

        mob1.name = "Mob01";
        mob1.hp = 20;
        mob1.armor = 1;
        mob1.attack = 3;
        mob1.attackSpeed = 0.7f;
        mob1.attackRange = 1f;
        mob1.speed = 1;
        mob1.job = 0;

        mob2.name = "Mob02";
        mob2.hp = 20;
        mob2.armor = 1;
        mob2.attack = 3;
        mob2.attackSpeed = 0.7f;
        mob2.attackRange = 5f;
        mob2.speed = 1;
        mob2.job = 1;

        // input mob in waves
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].mob1 = mob1;
            waves[i].mob2 = mob2;
            waves[i].mob3 = mob1;
            waves[i].mob4 = mob1;
        }

        // go to InGame
        InGameStage();
    }

    public void Stage_3()
    {
        // reward
        gold = 600;
        

        // three waves
        waves = new Wave[3];

        // mob1 stat
        Mob mob1 = new Mob();
        Mob mob2 = new Mob();
        Mob mob3 = new Mob();

        mob1.name = "Mob01";
        mob1.hp = 20;
        mob1.armor = 1;
        mob1.attack = 3;
        mob1.attackSpeed = 0.7f;
        mob1.attackRange = 1f;
        mob1.speed = 1;
        mob1.job = 0;

        mob2.name = "Mob02";
        mob2.hp = 20;
        mob2.armor = 1;
        mob2.attack = 3;
        mob2.attackSpeed = 0.7f;
        mob2.attackRange = 5f;
        mob2.speed = 1;
        mob2.job = 1;

        mob3.name = "Mob06";
        mob3.hp = 20;
        mob3.armor = 1;
        mob3.attack = 3;
        mob3.attackSpeed = 0.7f;
        mob3.attackRange = 3f;
        mob3.speed = 1;
        mob3.job = 2;

        // input mob in waves
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].mob1 = mob1;
            waves[i].mob2 = mob2;
            waves[i].mob3 = mob3;
            waves[i].mob4 = mob1;
        }

        // go to InGame
        InGameStage();
    }

    public void Stage_4()
    {
        // reward
        gold = 800;
        

        // three waves
        waves = new Wave[3];

        // mob1 stat
        Mob mob1 = new Mob();
        Mob mob2 = new Mob();
        Mob mob3 = new Mob();
        Mob mob4 = new Mob();

        mob1.name = "Mob01";
        mob1.hp = 25;
        mob1.armor = 1;
        mob1.attack = 4;
        mob1.attackSpeed = 0.7f;
        mob1.attackRange = 1f;
        mob1.speed = 1;
        mob1.job = 0;
        mob1.canCallTeam = true;

        mob2.name = "Mob02";
        mob2.hp = 25;
        mob2.armor = 1;
        mob2.attack = 4;
        mob2.attackSpeed = 0.7f;
        mob2.attackRange = 5f;
        mob2.speed = 1;
        mob2.job = 1;
        mob2.canCallTeam = true;

        mob3.name = "Mob03";
        mob3.hp = 25;
        mob3.armor = 1;
        mob3.attack = 4;
        mob3.attackSpeed = 0.7f;
        mob3.attackRange = 3f;
        mob3.speed = 1;
        mob3.job = 2;
        mob3.canCallTeam = true;

        mob4.name = "Boss01";
        mob4.hp = 60;
        mob4.armor = 2;
        mob4.attack = 6;
        mob4.attackSpeed = 1f;
        mob4.attackRange = 3f;
        mob4.speed = 1;
        mob4.job = 0;
        mob4.canSkill = true;

        // input mob in waves
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].mob1 = mob1;
            waves[i].mob2 = mob2;
            waves[i].mob3 = mob3;
            waves[i].mob4 = mob1;
        }

        boss = mob4;

        // go to InGame
        InGameStage();
    }
}
