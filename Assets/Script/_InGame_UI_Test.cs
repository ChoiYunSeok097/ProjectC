using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _InGame_UI_Test : MonoBehaviour
{
    int button01;
    int button02;
    int button03;

    public float speed;    // 하단 스킬cost 게이지바의 속도값
    public float skillCost; // 하단 스킬cost 게이지바의 수치
    public Image SkillCost_Front; //줄어드는 게이지바 이미지를 가져와서 fillAmount값 활용 목적




  
    // Start is called before the first frame update
    void Start()
    {
        skillCost = 0;
        speed = 3.0f;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(skillCost >= 10) return;  //Max값일때 더이상 게이지가 차오르지 않도록 리턴후 실행 취소

        skillCost += Time.deltaTime * speed;   //게이지 차오르는 속도

        SkillCost_Front.fillAmount = skillCost / 10;  //UI 게이지바 값변화



    }
}
