using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _InGame_UI_TimeCount : MonoBehaviour
{
    float timeCount;
    public Text[] timeCountText;

   
       void Update()
    {
        TimeCountText();
    }
    public void TimeCountText()   // IngameUI_TimeCount 00:00:00
    {
        timeCount += Time.deltaTime;
        int a_hour = (int)(timeCount / 3600);
        int a_min = (int)timeCount % 3600 / 60;
        int a_sec = (int)timeCount % 3600 % 60;
        timeCountText[0].text = ((int)a_hour).ToString("D2");
        timeCountText[1].text = ((int)a_min).ToString("D2");
        timeCountText[2].text = ((int)a_sec).ToString("D2");
    }
}
