using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _InGame_SkillCoolTime : MonoBehaviour
{
    
    public Image image;                 //스킬 이미지
    public Button button;               //스킬 버튼
    public float coolTime = 10.0f;      //쿨타임 시간
    public bool isClicked = false;      //버튼이 클릭 되었는가
    float leftTime = 10.0f;             //남은 시간
    float speed = 5.0f;                 //채우는 시간

    // Update is called once per frame
    void Update () 
    {
        
        if(isClicked)                                       // 버튼이 클릭되었다면
            if (leftTime > 0)                               // 남은 시간이 존재 할 시
            {
            leftTime -= Time.deltaTime * speed;             // 남은 시간 감소
            if(leftTime < 0)                                // 남은 시간이 없을 시
            {
                leftTime = 0;                               // 남은 시간을 0으로 초기화
                if(button)                                  // 버튼이 존재 할 시
                    button.enabled = true;                  // 버튼 기능 활성화
                isClicked = true;                           // 
            }
        
            float ratio = 1.0f - (leftTime / coolTime);     // ratio 변수에 저장, 1.0f이 다 채워진 상태를 의미, 1.0f에서 쿨타임과 남은 시간을 나눈 비율을 뺌
            if(image)                                       // 이미지가 존재 할 시
                image.fillAmount = ratio;                   // 이미지에 ratio를 반영
            }
    }

    public void StartCoolTime() 
    {
        leftTime = coolTime;                                        // 남은 시간을 쿨타임시간으로 초기화
        isClicked = true;                                           // 클릭되었음을 변수에 저장
        
        if(button)                                                  // 버튼이 존재 할 시
            button.enabled = false;                                 // 버튼 기능을 해지함.
    }
}
