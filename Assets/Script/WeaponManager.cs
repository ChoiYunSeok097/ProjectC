using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //0:�Ѽհ� 1:�μհ� 2:���� 3:Ȱ 4:ȭ�� 5:�ϵ� 6:���� 7:�б�
    protected int type;
    public float Attack;
    public float Health;
    public float Guard;
    protected int Weapons_Lv;
    protected int[] NeedExp;
    protected int CurrentExp;
    protected void LevelST()
    {
        for (int i = 0; i < NeedExp.Length; i++)
        {
            NeedExp[i] = 250 + 250 * i;
        }
    }
    protected void LevelUp()
    {
        if (Weapons_Lv != NeedExp.Length)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                CurrentExp += 2000;
            }
        }
        else if (Weapons_Lv == NeedExp.Length)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                Debug.Log("�����޼�");
            }
        }
        if (NeedExp[Weapons_Lv - 1] <= CurrentExp)
        {
            CurrentExp -= NeedExp[Weapons_Lv - 1];
            ++Weapons_Lv;
            LevelStat();
        }
    }

    void LevelStat()
    {
        Attack += Attack / 55.0f;
        Guard += Guard / 55.0f;
        Health += Health / 55.0f;
    }
}
