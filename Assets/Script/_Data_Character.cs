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
    GameObject targetEnemy;
    enum CHARSTATE { idle, battle};
    CHARSTATE charState;
    Animator anim;
    Rigidbody rigidbody;
    Transform hpPos;
    Image Hp;
    Image HpMax;
    Image hpImage;
    Image hpMaxImage;
    
    protected Vector3 screenPos;

    // stat
    float hp=4,armor=1,attack=2,attackSpeed=1,attackRange=1,speed=1,attackColTime;

    public _Data_Character()
    {
        stat = new Character();
    }

    void Awake() 
    {
        enemyList = new Queue<GameObject>();
        goalPos = gameObject.transform.position;
        goalPos.z += 138;

        CHARSTATE charState = CHARSTATE.idle;
        anim = gameObject.GetComponent<Animator>();

        rigidbody = gameObject.GetComponent<Rigidbody>();

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

        attackColTime += Time.deltaTime;
        rigidbody.velocity =Vector3.zero;
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
    }
    void defaultMove()
    {
        if(anim.GetBool("isMove") != true)
            anim.SetBool("isMove",true);
        transform.position = Vector3.MoveTowards(transform.position, goalPos, speed*Time.deltaTime);
        
    }

    void SearchEnemy()
    {
        characterTurn();
        Collider[] cols = Physics.OverlapSphere(transform.position, 6f);

        if(cols.Length > 0) 
        {
            for (int i = 0; i < cols.Length; i++) 
            {
                //Debug.Log("find");
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
        // set battle state
        //charState = CHARSTATE.battle;

        // calculation enemy distance
        if(Vector3.Distance(transform.position, _enemy.transform.position)<1.5f)
        {
            // attack enemy
            if( attackColTime >= 1/attackSpeed)
            {
                // motion
                if(anim.GetBool("isMove") == true)
                    anim.SetBool("isMove",false);
                anim.SetTrigger("Attack");

                attackColTime = 0;

                // give demage
                _enemy.GetComponent<_Data_Enemy>().TakeDemage(attack);
            }
        }
        else
        {
            //motion
            if(anim.GetBool("isMove") != true)
                anim.SetBool("isMove",true);

            // move to enemy
            Vector3 target = new Vector3(_enemy.transform.position.x,0,_enemy.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, _enemy.transform.position , speed*Time.deltaTime);

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
        Debug.Log(stat.hp+"\n");
        Debug.Log(hp);
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
