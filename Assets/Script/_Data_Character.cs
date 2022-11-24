using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class _Data_Character : MonoBehaviour
{
    public Character stat;
    public Vector3 goalPos;
    Queue<GameObject> enemyList;
    public GameObject targetEnemy;
    public GameObject throwItem;

    Animator anim;
    Transform hpPos;
    Image Hp;
    Image HpMax;
    Image hpImage;
    Image hpMaxImage;
    
    Vector3 screenPos;

    public bool isSkill;

    // stat
    public float hp=1,armor=1,attack=1,attackSpeed=1,attackRange=1,speed=1,attackColTime,job;

    public _Data_Character()
    {
        stat = new Character();
    }

    void Awake() 
    {
        // target setting
        enemyList = new Queue<GameObject>();
        goalPos = gameObject.transform.position;
        goalPos.z += 138;

        // anim
        anim = gameObject.GetComponent<Animator>();
        isSkill = false;

        // HP setting
        var canvas = GameObject.Find("Canvas");
        Hp = Resources.Load<Image>("UI_Ingame/"+"Hp");
        HpMax = Resources.Load<Image>("UI_Ingame/"+"HpMax");
        hpMaxImage = Instantiate<Image>(HpMax);
        hpImage = Instantiate<Image>(Hp);
        hpMaxImage.transform.SetParent(canvas.transform);
        hpImage.transform.SetParent(canvas.transform);
        hpPos = transform.Find("HpPos");
        HpPosition();    
    }

    void start()
    {
        //InvokeRepeating
        
    }

    void Update()
    {
        // find enemy
        SearchEnemy();

        // time
        attackColTime += Time.deltaTime;

        // ui
        HpPosition();
    }

    public void setStat(Character _stat)
    {
        stat = _stat;
        hp = stat.hp;
        armor = stat.armor;
        attack = stat.attack;
        attackSpeed = stat.attackSpeed;
        attackRange = stat.attackRange;
        speed = stat.speed;
        job = stat.job;

        if (job == 1)
        {
            throwItem = Resources.Load<GameObject>("Prefab/Item/Arrows");
        }
    }
    void defaultMove()
    {
        if(anim.GetBool("isMove") != true)
            anim.SetBool("isMove",true);
        transform.position = Vector3.MoveTowards(transform.position, goalPos, speed*Time.deltaTime);
        
    }

    void SearchEnemy()
    {
        // turn to target
        characterTurn();

        // search objects
        Collider[] cols = Physics.OverlapSphere(transform.position, 6f);
        if(cols.Length > 0) 
        {
            for (int i = 0; i < cols.Length; i++) 
            {
                if (cols[i].tag == "Enemy") 
                {
                    
                    if(!enemyList.Contains(cols[i].gameObject))
                    {
                        enemyList.Enqueue(cols[i].gameObject);
                    }       
                }
            }
        }

        // have no target
        if(targetEnemy == null)
        {
            if(enemyList.Count != 0)
                targetEnemy = enemyList.Dequeue();
            else
                defaultMove();
        }

        // if enemyAlive
        else if(targetEnemy.activeSelf != false)
        {
            AttackEnemy(targetEnemy);
        }
        else if(targetEnemy.activeSelf == false)
        {
            targetEnemy = null;
        }
    }

    void AttackEnemy(GameObject _enemy)
    {
        // calculation enemy distance
        if (!isSkill)
        {
            if (Vector3.Distance(transform.position, _enemy.transform.position) < attackRange)
            {
                // attack enemy
                if (attackColTime >= 1 / attackSpeed)
                {
                    // motion
                    // set no move
                    if (anim.GetBool("isMove") == true)
                        anim.SetBool("isMove", false);
                    anim.SetTrigger("Attack");

                    attackColTime = 0;

                    // give demage
                    if(job == 0)
                        _enemy.GetComponent<_Data_Enemy>().TakeDemage(attack);
                    else if(job == 1)
                    {
                        //ThrowWeapon(throwItem, _enemy, transform.position);
                    }
                }
            }
            else
            {
                //motion
                // set Move
                if (anim.GetBool("isMove") != true)
                    anim.SetBool("isMove", true);

                // move to enemy
                Vector3 target = new Vector3(_enemy.transform.position.x, 0, _enemy.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, _enemy.transform.position, speed * Time.deltaTime);
            }
        }
    }

    public void Skill()
    {
        // motion
        anim.SetTrigger("skill");

        // character type

        // sword and sheid skill
        if(job == 0)
        {
            //hp += 5;
            // search objects
            Collider[] cols = Physics.OverlapSphere(transform.position, 3f);
            if (cols.Length > 0)
            {
                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].tag == "Heroes")
                    {
                        cols[i].GetComponent<_Data_Character>().TakeHp(3);
                    }
                    else if (cols[i].tag == "Enemy")
                    {
                        cols[i].GetComponent<_Data_Enemy>().TakeDemage(3);
                    }
                }
            }
        }


    }

    void characterTurn()
    {
        if(targetEnemy != null)
        {
            transform.LookAt(targetEnemy.transform);
        }
        else
            transform.LookAt(goalPos);
    }


    public void TakeDemage(float _demage)
    {
        float demage = _demage - armor;
        if(demage > 0)
            hp -= demage;

        if(hp <= 0)
        {
            gameObject.SetActive(false);
            hpImage.gameObject.SetActive(false);
            hpMaxImage.gameObject.SetActive(false);
        }
    }

    public void TakeHp(float _heal)
    {
        if (hp < 0) return;             // if dead

        if ((hp + _heal) > stat.hp)     // if maxhp < heal
            hp = stat.hp;
        else
            hp += _heal;
    }

    void HpPosition()
    {
        screenPos = Camera.main.WorldToScreenPoint(hpPos.transform.position);
        hpImage.transform.position = screenPos;
        hpMaxImage.transform.position = screenPos;
        if(hp<=0) hp = 0;
        hpImage.fillAmount = hp / stat.hp;
    }
    
}
