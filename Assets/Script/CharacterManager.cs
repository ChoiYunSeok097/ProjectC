using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    Vector3 enemy;
    EnemyManager enemyManager;
    GameObject[] Enemys;
    GameObject[] Heroes;
    protected string CharName;
    protected int Character_Lv = 1;
    protected int[] NeedExp;
    protected int CurrentExp = 0;
    protected int Job;
    protected float Damage;
    public float time;
    public float damage
    {
        get { return Damage; }
        set { Damage = value; }
    }
    //0:검방패 1: 한손검/ 2:더블검/ 3:두손검/ 4:둔기병/ 5:궁수/ 6:마법사/ 7:신관
    protected int Grade;
    protected float MaxHealth, AttackSpeed;
    public float CurrentHealth, Attack, Guard;
    protected void LevelST()
    {
        for (int i = 0; i < NeedExp.Length; i++)
        {
            NeedExp[i] = 250 + 250 * i;
        }
    }
    protected void LevelUp()
    {
        if(Character_Lv != NeedExp.Length)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                CurrentExp += 2000;
            }
        }
        else if (Character_Lv == NeedExp.Length)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                Debug.Log("만렙달성");
            }
        }
        if (NeedExp[Character_Lv-1] <= CurrentExp)
        {
            CurrentExp -= NeedExp[Character_Lv-1];
            ++Character_Lv;
            LevelStat();
        }
    }
    EnemyManager CloseEnemyObject()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject enemy = null;
        float distance = Mathf.Infinity;
        Vector3 positon = transform.position;
        foreach(GameObject one in Enemys)
        {
            float distance2 = Vector3.Distance(one.transform.position, transform.position);
            if(distance2 < distance)
            {
                enemy = one;
                distance = distance2;
            }
        }
        if (Enemys.Length == 0)
        {
            Debug.Log("승리");
            return null;
        }
        EnemyManager enemymanager = enemy.GetComponent<EnemyManager>();
        return enemymanager;
    }

    EnemyManager farEnemyObject()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject enemy = null;
        float distance = 0f;
        Vector3 positon = transform.position;
        foreach (GameObject one in Enemys)
        {
            float distance2 = Vector3.Distance(one.transform.position, transform.position);
            if (distance2 > distance)
            {
                enemy = one;
                distance = distance2;
            }
        }
        if (Enemys.Length == 0)
        {
            Debug.Log("승리");
            return null;
        }
        EnemyManager enemymanager = enemy.GetComponent<EnemyManager>();
        return enemymanager;
    }

    void LevelStat()
    {
        Attack += 0.6f * Grade;
        Guard += 0.1f * Grade;
        MaxHealth += 5f * Grade;
        CurrentHealth = MaxHealth;
    }
    protected void AttackMotion()
    {
        enemyManager = CloseEnemyObject();
        if (enemyManager == null)
        {
            Debug.Log("완료");
            gameObject.GetComponent<Animator>().SetInteger("AniIndex", 0);
            return;
        }
        enemyManager.Damage = Attack;
        gameObject.GetComponent<Animator>().SetInteger("AniIndex", 1);
        enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
    }
    protected void Wars()
    {
        time += Time.deltaTime * AttackSpeed;
        if (time >= 2f)
        {
            AttackMotion();
        }
    }
    public void Battle(float damage)
    {
        CurrentHealth = CurrentHealth - (damage - (damage * (Guard / 250)));
        if (CurrentHealth < 0f)
        {
            Destroy(gameObject);
        }
    }
    protected void Skill(int job)
    {
        switch (job)
        {
            case 0:
                SwordAndShieldSkill();
                break;
            case 1:
                SingleSwordSkill();
                break;
            case 2:
                DoubleSwordSkill();
                break;
            case 3:
                TwoHandSwordSkill();
                break;
            case 4:
                BowSkill();
                break;
            case 5:
                MagicionSkill();
                break;
            case 6:
                PristSkill();
                break;
        }
    }
    protected void SwordAndShieldSkill()
    {
        //주변적에게 피해를 입히고 체력회복
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemys.Length > 0)
        {
            for(int i = 0; i < Enemys.Length; i++)
            {
                enemyManager = Enemys[i].gameObject.GetComponent<EnemyManager>();
                float a = enemyManager.CurrentHealth;
                a = a - ((Attack * 4) - ((Attack * 4) * enemyManager.Guard / 250));
                enemyManager.CurrentHealth = a;
                if (CurrentHealth < MaxHealth)
                {
                    CurrentHealth += Attack * 3;
                    if(CurrentHealth > MaxHealth)
                    {
                        CurrentHealth = MaxHealth;
                    }
                }
                enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
            }
            time = 0f;
        }
    }
    protected void SingleSwordSkill()
    {
        enemyManager = CloseEnemyObject();
        float a = enemyManager.CurrentHealth;
        a = a - ((Attack * 6) - ((Attack * 6) * enemyManager.Guard / 250));
        enemyManager.CurrentHealth = a;
        enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
        gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
        time = 0f;
    }
    
    protected void DoubleSwordSkill()
    {
        //빙글빙글돌면서 주변적에게 피해
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                enemyManager = Enemys[i].gameObject.GetComponent<EnemyManager>();
                float a = enemyManager.CurrentHealth;
                a = a - ((Attack * 5) - ((Attack * 5) * enemyManager.Guard / 250));
                enemyManager.CurrentHealth = a;
                enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
            }
            time = 0f;
        }
    }
    protected void TwoHandSwordSkill()
    {
        //공중에서 내려찍으면서 주변적에게 피해
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                enemyManager = Enemys[i].gameObject.GetComponent<EnemyManager>();
                float a = enemyManager.CurrentHealth;
                a = a - ((Attack * 6) - ((Attack * 6) * enemyManager.Guard / 250));
                enemyManager.CurrentHealth = a;
                enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
            }
            time = 0f;
        }
    }
    protected void BowSkill()
    {
        //빠르게 3발발사후 전체공격기 한방
        enemyManager = farEnemyObject();
        float a = enemyManager.CurrentHealth;
        a = a - ((Attack * 6) - ((Attack * 6) * enemyManager.Guard / 250));
        enemyManager.CurrentHealth = a;
        enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
        gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
        time = 0f;
    }
    protected void MagicionSkill()
    {
        //범위를 지정해서 범위내의 적에게 피해
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                enemyManager = Enemys[i].gameObject.GetComponent<EnemyManager>();
                float a = enemyManager.CurrentHealth;
                a = a - ((Attack * 8) - ((Attack * 8) * enemyManager.Guard / 250));
                enemyManager.CurrentHealth = a;
                enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
            }
            time = 0f;
        }
    }
    protected void PristSkill()
    {
        Heroes = GameObject.FindGameObjectsWithTag("Heroes");
        if (Heroes.Length > 0)
        {
            for (int i = 0; i < Heroes.Length; i++)
            {
                CharacterManager characterManager = Heroes[i].gameObject.GetComponent<CharacterManager>();
                float a = characterManager.CurrentHealth;
                float b = characterManager.MaxHealth;
                if(a < b)
                {
                    a = a + Attack * 4;
                    characterManager.CurrentHealth = a;
                    if(characterManager.CurrentHealth > b)
                    {
                        characterManager.CurrentHealth = b;
                    }
                }
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
            }
            time = 0f;
        }
    }
    protected void Weapon1(GameObject weapon_1)
    {
        if(weapon_1 != null)
        {
            if(weapon_1.name == gameObject.transform.name + "_1")
            {
                float a = weapon_1.GetComponent<WeaponManager>().Attack;
                float b = weapon_1.GetComponent<WeaponManager>().Health;
                float c = weapon_1.GetComponent<WeaponManager>().Guard;
                Attack = Attack + a;
                MaxHealth = MaxHealth + b;
                CurrentHealth = MaxHealth;
                Guard = Guard + c;
            }
        }
    }
    protected void Weapon2(GameObject weapon_2)
    {
        if (weapon_2 != null)
        {
            if (weapon_2.name == gameObject.transform.name + "_2")
            {
                float a = weapon_2.GetComponent<WeaponManager>().Attack;
                float b = weapon_2.GetComponent<WeaponManager>().Health;
                float c = weapon_2.GetComponent<WeaponManager>().Guard;
                Attack = Attack + a;
                MaxHealth = MaxHealth + b;
                CurrentHealth = MaxHealth;
                Guard = Guard + c;
            }
        }
    }
}

