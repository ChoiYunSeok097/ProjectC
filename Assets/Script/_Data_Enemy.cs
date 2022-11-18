using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Data_Enemy : MonoBehaviour
{
    GameObject targetPlayer;
    Queue<GameObject> PlayerList;
    Animator anim;
    float hp=5,armor=1,attack=2,attackSpeed=1,attackRange=1,speed=1,attackColTime=0;
    Mob stat;

    Transform hpPos;
    Image Hp;
    Image HpMax;
    Image hpImage;
    Image hpMaxImage;
    Vector3 screenPos;

    private void Awake() 
    {
        
        PlayerList = new Queue<GameObject>();
        anim = gameObject.GetComponent<Animator>();

        // HP ui setting
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

    void Start()
    {
        
    }
    public void setStat(Mob _stat)
    {
        stat = _stat;
        hp = stat.hp;
        armor = stat.armor;
        attack = stat.attack;
        attackSpeed = stat.attackSpeed;
        attackRange = stat.attackRange;
        speed = stat.speed;
    }

    void Update()
    {
        // find enemy
        SearchEnemy();

        attackColTime += Time.deltaTime;

        // ui
        HpPosition();
    }

    void SearchEnemy()
    {
        // turn to target
        characterTurn();

        Collider[] cols = Physics.OverlapSphere(transform.position, 6f);

        if(cols.Length > 0) 
        {
            for (int i = 0; i < cols.Length; i++) 
            {
                //Debug.Log("find");
                if (cols[i].tag == "Heroes") 
                {
                    
                    if(!PlayerList.Contains(cols[i].gameObject))
                    {
                        PlayerList.Enqueue(cols[i].gameObject);
                    }       
                }
            }
        }

        // have no target
        if(targetPlayer == null)
        {
            if(PlayerList.Count != 0)
                targetPlayer = PlayerList.Dequeue();
        }

        // if enemyAlive
        else if(targetPlayer.activeSelf != false)
        {
            AttackPlayer(targetPlayer);
        }
        else if(targetPlayer.activeSelf == false)
        {
            targetPlayer = null;
        }
    }

    void AttackPlayer(GameObject _Player)
    {

        // calculation enemy distance
        if(Vector3.Distance(transform.position, _Player.transform.position)<1.5f)
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
                _Player.GetComponent<_Data_Character>().TakeDemage(attack);
            }
        }
        else
        {
            //motion
            if(anim.GetBool("isMove") != true)
                anim.SetBool("isMove",true);

            // move to enemy
            //Vector3 target = new Vector3(_Player.transform.position.x,0,_Player.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, _Player.transform.position , 1.5f*Time.deltaTime);

        }
    }
    void characterTurn()
    {
        if(targetPlayer != null)
        {
            transform.LookAt(targetPlayer.transform);
        }
        //else
            //transform.LookAt(targetPlayer.transform);
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

    void HpPosition()
    {
        screenPos = Camera.main.WorldToScreenPoint(hpPos.transform.position);
        hpImage.transform.position = screenPos;
        hpMaxImage.transform.position = screenPos;
        if(hp<=0) hp = 0;
        hpImage.fillAmount = hp / stat.hp;

    }
}
