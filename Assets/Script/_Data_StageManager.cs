using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class _Data_StageManager : MonoBehaviour
{
    public static Wave[] waves;

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
        SceneManager.LoadScene("InGame_Battle");
    }
    public void Backspace()
    {
        SceneManager.LoadScene("MainLobby");
    }


    public void Stage_1()
    {
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
        SceneManager.LoadScene("InGame_Battle");

    }
}
