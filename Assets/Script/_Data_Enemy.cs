using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Data_Enemy : MonoBehaviour
{
    GameObject targetPlayer;
    Queue<GameObject> PlayerList;
    Animator anim;
    float hp=5,armor=1,attack=2,attackSpeed=1,attackRange=1,speed=1,attackColTime=0;
    Mob stat;

    private void Awake() 
    {
        PlayerList = new Queue<GameObject>();
        anim = gameObject.GetComponent<Animator>();


    }

    void Start()
    {
        
    }

    void Update()
    {
        // find enemy
        SearchEnemy();

        attackColTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag == "Heroes")
            PlayerList.Enqueue(other.gameObject);

    }

    void SearchEnemy()
    {
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
        // set battle state
        //charState = CHARSTATE.battle;

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

    public void TakeDemage(float _demage)
    {
        float demage = _demage - armor;

        if(demage > 0)
            hp -= demage;

        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
