using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class _Data_Character : MonoBehaviour
{
    public string team;
    public string enemy;

    public Character playerStat;
    public Mob mobStat;
    public Vector3 goalPos;

    Queue<GameObject> enemyList;
    GameObject skill, effect;

    public GameObject targetEnemy;
    public GameObject throwItem;

    public _InGame_SkillCoolTime skillBtn;

    public AudioSource audioSource;
    

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
    bool canSkill,canCallTeam,isBattle;

    public _Data_Character()
    {
        playerStat = new Character();
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
        var canvas = GameObject.Find("Canvas").transform.GetChild(0);
        Hp = Resources.Load<Image>("UI_Ingame/"+"Hp");
        HpMax = Resources.Load<Image>("UI_Ingame/"+"HpMax");
        hpMaxImage = Instantiate<Image>(HpMax);
        hpImage = Instantiate<Image>(Hp);
        hpMaxImage.transform.SetParent(canvas.transform);
        hpImage.transform.SetParent(canvas.transform);
        hpPos = transform.Find("HpPos");
        HpPosition();

        // audio
        audioSource = gameObject.AddComponent<AudioSource>();

    }

    void Start()
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
        playerStat = _stat;
        hp = playerStat.hp;
        armor = playerStat.armor;
        attack = playerStat.attack;
        attackSpeed = playerStat.attackSpeed;
        attackRange = playerStat.attackRange;
        speed = playerStat.speed;
        job = playerStat.job;

        // player or enemy

        team = gameObject.tag;
        if (gameObject.tag == "Heroes")    // if player character
        {    
            enemy = "Enemy";
        }
        else if(gameObject.tag == "Enemy")
        {    
            enemy = "Heroes";
        }
        // attack per job
        if (job == 1)
        {
            throwItem = Resources.Load<GameObject>("Prefab/Item/Arrows");
        }
        if (job == 2)
        {
            throwItem = Resources.Load<GameObject>("Prefab/Item/balt");
        }
    }
    public void setStat(Mob _stat)
    {
        mobStat = _stat;
        hp = mobStat.hp;
        armor = mobStat.armor;
        attack = mobStat.attack;
        attackSpeed = mobStat.attackSpeed;
        attackRange = mobStat.attackRange;
        speed = mobStat.speed;
        job = mobStat.job;
        canSkill = mobStat.canSkill;
        canCallTeam = mobStat.canCallTeam;

        team = gameObject.tag;
        if (gameObject.tag == "Heroes")    // if player character
        {
            enemy = "Enemy";
        }
        else if (gameObject.tag == "Enemy")
        {
            enemy = "Heroes";
        }
        // attack per job
        if (job == 1)
        {
            throwItem = Resources.Load<GameObject>("Prefab/Item/Arrows");
        }
        if (job == 2)
        {
            throwItem = Resources.Load<GameObject>("Prefab/Item/balt");
        }
    }
    void defaultMove()
    {
        if (team == "Heroes")
        {
            if (anim.GetBool("isMove") != true)
                anim.SetBool("isMove", true);
            transform.position = Vector3.MoveTowards(transform.position, goalPos, speed * Time.deltaTime);
        }
    }

    void SearchEnemy()
    {  
        // turn to target
        characterTurn();
     
        // search objects
        Collider[] cols = Physics.OverlapSphere(transform.position, 6f);
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].tag == enemy)
                {

                    if (!enemyList.Contains(cols[i].gameObject))
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
            //Debug.Log(transform.name + " vs " + targetEnemy.name);
            AttackEnemy(targetEnemy);
        }
        else if(targetEnemy.activeSelf == false)
        {
            targetEnemy = null;
        }

        // isBattle
        if (targetEnemy == null)
        {
            isBattle = false;
        }
        else
            isBattle = true;
    }

    void AttackEnemy(GameObject _enemy)
    {
        
        if (!isSkill)
        {
            // calculation enemy distance
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
                    if (job == 0)
                    {
                        //if(team == "Heroes")
                            _enemy.GetComponent<_Data_Character>().TakeDemage(attack);
                       
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

    public bool Skill()
    {
        

        // character type

        // sword and sheid skill
        if(job == 0)
        {
            // motion
            anim.SetTrigger("skill");

            // search objects
            Collider[] cols = Physics.OverlapSphere(transform.position, 3f);
            if (cols.Length > 0)
            {
                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].tag == team)
                    {
                        cols[i].GetComponent<_Data_Character>().TakeHp(3);
                    }              
                }
                effect = Resources.Load<GameObject>("Effect/FantasySun"); // skill effect
                skill = Instantiate<GameObject>(effect); // create
                skill.transform.SetParent(transform, false);
                skill.transform.position = transform.position;       
            }
            return true;
        }

        if(job ==1)
        {
            if (targetEnemy != null)
            {
                // motion
                anim.SetTrigger("skill");

                _Data_Character enemy = targetEnemy.GetComponent<_Data_Character>();           
                gameObject.GetComponent<Animator>().SetTrigger("skill"); // char skill motion               
                effect = Resources.Load<GameObject>("Effect/LigthningState"); // skill effect
                skill = Instantiate<GameObject>(effect); // create
                skill.transform.SetParent(transform, false);
                skill.transform.position = gameObject.transform.position;
                return true;
            }
            else
            {
                return false;
            }
        }
        if (job == 2)
        {
            // motion
            anim.SetTrigger("skill");

            // search objects
            Collider[] cols = Physics.OverlapSphere(transform.position, 10f);
            if (cols.Length > 0)
            {
                for (int i = 0; i < cols.Length; i++)
                {        
                    if (cols[i].tag == enemy)
                    {
                        cols[i].GetComponent<_Data_Character>().TakeDemage(10);
                    }
                }
                //_Data_Enemy enemy = targetEnemy.GetComponent<_Data_Enemy>();
                //gameObject.GetComponent<Animator>().SetTrigger("skill"); // char skill motion
                effect = Resources.Load<GameObject>("Effect/MagicCircleExplode"); // skill effect
                skill = Instantiate<GameObject>(effect); // create
                skill.transform.SetParent(transform, false);
                skill.transform.position = gameObject.transform.position;       
            }
            return true;
        }

        return false;
    }

    public void bossSkill()
    {
        
        anim.SetTrigger("skill");
        effect = Resources.Load<GameObject>("Effect/FantasySun"); // skill effect
        skill = Instantiate<GameObject>(effect); // create
        skill.transform.SetParent(transform, false);
        skill.transform.position = gameObject.transform.position;

        Mob mob1 = new Mob();
        mob1.name = "Mob01";
        mob1.hp = 20;
        mob1.armor = 1;
        mob1.attack = 3;
        mob1.attackSpeed = 0.7f;
        mob1.attackRange = 1f;
        mob1.speed = 1;
        mob1.job = 0;

        GameObject parent = GameObject.Find("Enemy");
        Vector3 pos01 = transform.position;
        Vector3 pos02 = transform.position;
        pos01.x += 3;
        pos02.x -= 3;

        _Data_InstanceManager.instance.createMob(parent.transform, pos01, mob1);
        _Data_InstanceManager.instance.createMob(parent.transform, pos02, mob1);
            
        
    }

    public void CallTeam()
    {
        // search objects
        Collider[] cols = Physics.OverlapSphere(transform.position, 20f);
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].tag == team)
                {
                    _Data_Character teamTmp = cols[i].gameObject.GetComponent<_Data_Character>();
                    if(!teamTmp.isBattle)
                    {
                        teamTmp.targetEnemy = targetEnemy;
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
        else if(team == "Heroes")
            transform.LookAt(goalPos);
    }


    public void TakeDemage(float _demage)
    {
        float demage = _demage - armor;
        if(demage > 0)
            hp -= demage;

        if(hp <= 0)         // if character is dead
        {
            gameObject.SetActive(false);
            hpImage.gameObject.SetActive(false);
            hpMaxImage.gameObject.SetActive(false);

            if (team == "Heroes")
            {
                if (skillBtn != null)
                    skillBtn.disableBtn();
                GameObject.Find("GameManager").GetComponent<_Data_GameManager>().discountPlayer();
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<_Data_GameManager>().discountEnemy();
            }
        }

        if (hp < mobStat.hp / 2)
        {
            if (team == "Enemy" && canSkill == true)
            {
                bossSkill();
                canSkill = false;
            }
        }

        if(team == "Enemy")
        {
            if (canCallTeam)
                CallTeam();
        }
    }

    public void TakeHp(float _heal)
    {
        float maxHp = 0f;
        if (team == "Heroes") maxHp = playerStat.hp;
        else if (team == "Enemy") maxHp = mobStat.hp;

        if (hp < 0) return;             // if dead

        if ((hp + _heal) > maxHp)     // if maxhp < heal
            hp = maxHp;
        else
            hp += _heal;
    }

    void HpPosition()
    {
        float maxHp = 0f;
        if (team == "Heroes") maxHp = playerStat.hp;
        else if (team == "Enemy") maxHp = mobStat.hp;

        screenPos = Camera.main.WorldToScreenPoint(hpPos.transform.position);
        hpImage.transform.position = screenPos;
        hpMaxImage.transform.position = screenPos;
        if(hp<=0) hp = 0;
        hpImage.fillAmount = hp / maxHp;
    }
   
    public void SetAudio(AudioClip _clip)
    {
        audioSource.clip = _clip;
    }
    
    public void Sound()
    {
        audioSource.Play();
    }
}
