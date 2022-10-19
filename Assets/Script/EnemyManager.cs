using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public CharacterManager enemyManager;
    GameObject[] Enemys;
    GameObject[] Mobs;
    protected string MobName;
    protected int Stage, Job, BossJob;
    protected float MaxHealth, AttackSpeed;
    public float CurrentHealth, Attack, Damage, Guard;
    public float time;
    protected float SkillCooltime;
    protected float AttackRange, dist;
    protected NavMeshAgent pathFinder;
    protected bool canmove;
    public Transform hpPos;
    public Image Hp;
    protected Image hp;
    protected Vector3 screenPos;
    public int stage
    {
        get { return Stage; }
        set { Stage = value; }
    }
    void StageStat(int stage)
    {
        MaxHealth = MaxHealth + ((MaxHealth / 40) * stage);
        Attack = Attack + ((Attack / 40) * stage);
        Guard = Guard + ((Guard / 40) * stage);
    }
    public void Battle(float damage)
    {
        CurrentHealth = CurrentHealth - (damage * (100 / (100 + Guard)));
        if (CurrentHealth < 0f)
        {
            Destroy(gameObject);
            Debug.Log("죽었습니다");
        }
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
        /*enemyManager.damage = Attack;*/
        gameObject.GetComponent<Animator>().SetBool("CanAttack", true);
    }
    protected void Wars()
    {
        time += Time.deltaTime * AttackSpeed;
        if (time >= 2.5f)
        {
            AttackMotion();
        }
    }
    CharacterManager CloseEnemyObject()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Heroes");
        GameObject enemy = null;
        float distance = Mathf.Infinity;
        Vector3 positon = transform.position;
        foreach (GameObject one in Enemys)
        {
            float distance2 = Vector3.Distance(one.transform.position, transform.position);
            if (distance2 < distance)
            {
                enemy = one;
                distance = distance2;
            }
        }
        if(Enemys.Length == 0)
        {
            Debug.Log("패배");
            return null;
        }
        CharacterManager enemymanager = enemy.GetComponent<CharacterManager>();
        return enemymanager;
    }
    protected void BossSkill(int job)
    {
        switch (job)
        {
            case 0:
                BossSwordSkill();
                break;
            case 1:
                BossDoubleSwordSkill();
                break;
            case 2:
                BossBowSkill();
                break;
            case 3:
                BossWandSkill();
                break;
        }
    }
    protected void Skill(int job)
    {
        switch (job)
        {
            case 0:
                SwordSkill();
                break;
            case 1:
                BowSkill();
                break;
            case 2:
                WandSkill();
                break;
            case 3:
                PristSkill();
                break;
        }
    }
    protected void BossSwordSkill()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Heroes");
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                enemyManager = Enemys[i].gameObject.GetComponent<CharacterManager>();
                float a = enemyManager.CurrentHealth;
                a = a - ((Attack * 5) - ((Attack * 5) * enemyManager.Guard / 250));
                enemyManager.CurrentHealth = a;
                enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
            }
            time = 0f;
        }
    }
    protected void BossDoubleSwordSkill()
    {
        enemyManager = CloseEnemyObject();
        float a = enemyManager.CurrentHealth;
        a = a - ((Attack * 7) - ((Attack * 7) * enemyManager.Guard / 250));
        enemyManager.CurrentHealth = a;
        enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
        gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
        time = 0f;
    }
    protected void BossBowSkill()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Heroes");
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                enemyManager = Enemys[i].gameObject.GetComponent<CharacterManager>();
                float a = enemyManager.CurrentHealth;
                a = a - ((Attack * 6) - ((Attack * 6) * enemyManager.Guard / 250));
                enemyManager.CurrentHealth = a;
                enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
            }
            time = 0f;
        }
    }
    protected void BossWandSkill()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Heroes");
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                enemyManager = Enemys[i].gameObject.GetComponent<CharacterManager>();
                float a = enemyManager.CurrentHealth;
                a = a - ((Attack * 6) - ((Attack * 6) * enemyManager.Guard / 250));
                enemyManager.CurrentHealth = a;
                enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
            }
            time = 0f;
        }
    }
    protected void SwordSkill()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Heroes");
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                enemyManager = Enemys[i].gameObject.GetComponent<CharacterManager>();
                float a = enemyManager.CurrentHealth;
                a = a - ((Attack * 3) - ((Attack * 3) * enemyManager.Guard / 250));
                enemyManager.CurrentHealth = a;
                enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
            }
            time = 0f;
        }
    }
    protected void BowSkill()
    {
        enemyManager = CloseEnemyObject();
        float a = enemyManager.CurrentHealth;
        a = a - ((Attack * 5) - ((Attack * 5) * enemyManager.Guard / 250));
        enemyManager.CurrentHealth = a;
        enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
        gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
        time = 0f;
    }
    protected void WandSkill()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Heroes");
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                enemyManager = Enemys[i].gameObject.GetComponent<CharacterManager>();
                float a = enemyManager.CurrentHealth;
                a = a - ((Attack * 4) - ((Attack * 4) * enemyManager.Guard / 250));
                enemyManager.CurrentHealth = a;
                enemyManager.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
            }
            time = 0f;
        }
    }
    protected void PristSkill()
    {
        Mobs = GameObject.FindGameObjectsWithTag("Enemy");
        if (Mobs.Length > 0)
        {
            for (int i = 0; i < Mobs.Length; i++)
            {
                EnemyManager characterManager = Mobs[i].gameObject.GetComponent<EnemyManager>();
                float a = characterManager.CurrentHealth;
                float b = characterManager.MaxHealth;
                if (a < b)
                {
                    a = a + Attack * 2;
                    characterManager.CurrentHealth = a;
                    if (characterManager.CurrentHealth > b)
                    {
                        characterManager.CurrentHealth = b;
                    }
                }
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 2);
            }
            time = 0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag == "Heroes")
        {
            if(other.transform.root.GetComponent<Animator>().GetBool("CanAttack"))
            {
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
            }
        }
        if (other.transform.tag == "Weapon")
        {
            Damage = other.transform.GetComponent<WeaponAttack>().Attack;
            Battle(Damage);
            gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3);
        }
    }
    protected virtual void NavMove()
    {
        enemyManager = CloseEnemyObject();
        if (enemyManager != null)
        {
            dist = Vector3.Distance(gameObject.transform.position, enemyManager.transform.position);
            if (dist < AttackRange)
            {
                canmove = false;
                gameObject.GetComponent<Animator>().SetBool("CanMove", canmove);
                pathFinder.isStopped = true;
                gameObject.transform.LookAt(enemyManager.transform);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetInteger("AniIndex", 0);
                canmove = true;
                gameObject.GetComponent<Animator>().SetBool("CanMove", canmove);
                //계속 추적
                pathFinder.isStopped = false; //계속 이동
                pathFinder.SetDestination(enemyManager.transform.position);
            }
        }
        if (CurrentHealth <= 0)
        {

            this.gameObject.tag = "Die";
            this.gameObject.GetComponent<Animator>().SetTrigger("Dead");
            time += Time.deltaTime;
            if (time >= 3f)
            {
                Destroy(this.gameObject);
            }
        }
    }
    protected void HpPosition()
    {
        screenPos = Camera.main.WorldToScreenPoint(hpPos.transform.position);
        hp.transform.position = screenPos;
        hp.fillAmount = CurrentHealth / MaxHealth;
    }
}
