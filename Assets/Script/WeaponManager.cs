using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //0:한손검 1:두손검 2:방패 3:활 4:화살 5:완드 6:모자 7:둔기
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
                Debug.Log("만렙달성");
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
