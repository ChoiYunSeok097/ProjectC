using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _InGame_UI_Test : MonoBehaviour
{
    int button01;
    int button02;
    int button03;

    public float speed;    // �ϴ� ��ųcost ���������� �ӵ���
    public float skillCost; // �ϴ� ��ųcost ���������� ��ġ
    public Image SkillCost_Front; //�پ��� �������� �̹����� �����ͼ� fillAmount�� Ȱ�� ����




  
    // Start is called before the first frame update
    void Start()
    {
        skillCost = 0;
        speed = 3.0f;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(skillCost >= 10) return;  //Max���϶� ���̻� �������� �������� �ʵ��� ������ ���� ���

        skillCost += Time.deltaTime * speed;   //������ �������� �ӵ�

        SkillCost_Front.fillAmount = skillCost / 10;  //UI �������� ����ȭ



    }
}
