using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //AI, �׺���̼� �ý��� ���� �ڵ� ��������

public class BattleSystem : LivingEntity
{
    public LayerMask whatIsTarget; //������� ���̾�

    private BattleSystem targetEntity;//�������
    private NavMeshAgent pathFinder; //��� ��� AI ������Ʈ



    private Animator aiAnimator;


    public float damage = 20f; //���ݷ�
    public float attackDelay = 1f; //���� ������
    private float lastAttackTime; //������ ���� ����
    private float dist; //���������� �Ÿ�

    public Transform tr;

    private float attackRange = 2.3f;

    //���� ����� �����ϴ��� �˷��ִ� ������Ƽ
    private bool hasTarget
    {
        get
        {
            //������ ����� �����ϰ�, ����� ������� �ʾҴٸ� true
            if (targetEntity != null && !targetEntity.dead)
            {
                return true;
            }

            //�׷��� �ʴٸ� false
            return false;
        }
    }

    private bool canMove;
    private bool canAttack;

    private void Awake()
    {
        //���� ������Ʈ���� ����� ������Ʈ ��������
        pathFinder = GetComponent<NavMeshAgent>();
        aiAnimator = GetComponent<Animator>();
        //enemyAudioPlayer = GetComponent<AudioSource>();
    }

    //�� AI�� �ʱ� ������ �����ϴ� �¾� �޼���
    public void Setup(float newHealth, float newDamage, float newSpeed)
    {
        //ü�� ����
        startingHealth = newHealth;
        health = newHealth;
        //���ݷ� ����
        damage = newDamage;
        //�׺�޽� ������Ʈ�� �̵� �ӵ� ����
        pathFinder.speed = newSpeed;
    }


    void Start()
    {
        //���� ������Ʈ Ȱ��ȭ�� ���ÿ� AI�� Ž�� ��ƾ ����
        StartCoroutine(UpdatePath());
        tr = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        aiAnimator.SetBool("CanMove", canMove);
        aiAnimator.SetBool("CanAttack", canAttack);

        if (hasTarget)
        {
            //���� ����� ������ ��� �Ÿ� ����� �ǽð����� �ؾ��ϴ� Update()
            dist = Vector3.Distance(tr.position, targetEntity.transform.position);
        }
    }

    //������ ����� ��ġ�� �ֱ������� ã�� ��� ����
    private IEnumerator UpdatePath()
    {
        //��� �ִ� ���� ���� ����
        while (!dead)
        {
            if (hasTarget)
            {
                Attack();
            }
            else
            {
                //���� ����� ���� ���, AI �̵� ����
                pathFinder.isStopped = true;
                canAttack = false;
                canMove = false;

                //������ 20f�� �ݶ��̴��� whatIsTarget ���̾ ���� �ݶ��̴� �����ϱ�
                Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, whatIsTarget);

                //��� �ݶ��̴��� ��ȸ�ϸ鼭 ��� �ִ� LivingEntity ã��
                for (int i = 0; i < colliders.Length; i++)
                {
                    //�ݶ��̴��κ��� BattleSystem ������Ʈ ��������
                    BattleSystem battlesystem = colliders[i].GetComponent<BattleSystem>();

                    //LivingEntity ������Ʈ�� �����ϸ�, �ش� LivingEntity�� ��� �ִٸ�
                    if (battlesystem != null && !battlesystem.dead)
                    {
                        //���� ����� �ش� LivingEntity�� ����
                        targetEntity = battlesystem;

                        //for�� ���� ��� ����
                        break;
                    }
                }
            }

            //0.25�� �ֱ�� ó�� �ݺ�
            yield return new WaitForSeconds(0.25f);
        }
    }

    //���� ������ �Ÿ��� ���� ���� ����
    public virtual void Attack()
    {

        //�ڽ��� ���X, ���� ������ �Ÿ��� ���� ��Ÿ� �ȿ� �ִٸ�
        if (!dead && dist < attackRange)
        {
            //���� �ݰ� �ȿ� ������ �������� �����.
            canMove = false;
            pathFinder.isStopped = true;

            //���� ��� �ٶ󺸱�
            this.transform.LookAt(targetEntity.transform);

            //�ֱ� ���� �������� attackDelay �̻� �ð��� ������ ���� ����
            if (lastAttackTime + attackDelay <= Time.time)
            {
                canAttack = true;
                OnDamageEvent();
            }

            //���� �ݰ� �ȿ� ������, �����̰� �������� ���
            else
            {
                canAttack = false;
            }
        }

        //���� �ݰ� �ۿ� ���� ��� �����ϱ�
        else
        {
            canMove = true;
            canAttack = false;
            //��� ����
            pathFinder.isStopped = false; //��� �̵�
            pathFinder.SetDestination(targetEntity.transform.position);
        }
    }

    //����Ƽ �ִϸ��̼� �̺�Ʈ�� �ֵθ� �� ������ �����Ű��
    public void OnDamageEvent()
    {
        //���� ����� ������ ���� ����� LivingEntity ������Ʈ ��������
        BattleSystem attackTarget = targetEntity.GetComponent<BattleSystem>();

        //���� ó��
        attackTarget.OnDamage(damage);

        //�ֱ� ���� �ð� ����
        lastAttackTime = Time.time;
    }


    //�������� �Ծ��� �� ������ ó��
    public override void OnDamage(float damage)
    {




        //LivingEntity�� OnDamage()�� �����Ͽ� ������ ����
        base.OnDamage(damage);
    }

    //��� ó��
    public override void Die()
    {
        //LivingEntity�� DIe()�� �����Ͽ� �⺻ ��� ó�� ����
        base.Die();

        //�ٸ� AI�� �������� �ʵ��� �ڽ��� ��� �ݶ��̴��� ��Ȱ��ȭ
        Collider[] enemyColliders = GetComponents<Collider>();
        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }

        //AI������ �����ϰ� �׺�޽� ������Ʈ�� ��Ȱ��ȭ
        pathFinder.isStopped = true;
        pathFinder.enabled = false;

        //��� �ִϸ��̼� ���
        aiAnimator.SetTrigger("Die");
       
    }
}