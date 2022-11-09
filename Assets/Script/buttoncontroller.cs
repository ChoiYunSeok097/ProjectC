using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttoncontroller : MonoBehaviour
{
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
    public void button_200_inactive_down()
    {
        SceneManager.LoadScene("InGame_Battle");
    }
    public void Backspace()
    {
        SceneManager.LoadScene("MainLobby");
    }
}

