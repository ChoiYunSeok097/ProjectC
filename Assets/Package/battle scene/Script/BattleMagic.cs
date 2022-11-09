using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BattleMagic : LivingEntity
{
    public LayerMask whatIsTarget; //������� ���̾�

    private BattleSystem targetEntity;//�������
    private NavMeshAgent pathFinder; //��� ��� AI ������Ʈ
    private float dist; //���� ���������� �Ÿ�

 

    //������
    public GameObject firePoint; //�����̻����� �߻�� ��ġ
    public GameObject magicMissilePrefab; //����� �����̻��� �Ҵ�
    public GameObject magicMissile; //Instantiate()�޼���� �����ϴ� �����̻����� ��� ���ӿ�����Ʈ


    private Animator enemyAnimator;

    public float damage = 30f; //���ݷ�
    public float attackDelay = 2.5f; //���� ������
    private float lastAttackTime; //������ ���� ����

    public Transform tr;
    private float attackRange = 10f;

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
        enemyAnimator = GetComponent<Animator>();
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

        //���� ������ ���� �Ÿ� �����ϰ� �����ϱ�(7~10����), ���� �����ִ� �ͺ��� �갳�� ����� �ֱ� ���ؼ�
        pathFinder.stoppingDistance = Random.Range(7, 11);
    }

    // Update is called once per frame
    void Update()
    {
        //���� ����� ���� ���ο� ���� �ٸ� �ִϸ��̼� ���
        enemyAnimator.SetBool("CanMove", canMove);
        enemyAnimator.SetBool("CanAttack", canAttack);

        if (hasTarget)
        {
            //���� ����� ������ ��� �Ÿ� ����� �ǽð����� �ؾ��ϴ� Update()
            dist = Vector3.Distance(tr.position, targetEntity.transform.position);
        }


    }

    //������ ����� ��ġ�� �ֱ������� ã�� ��� ����, ����� ������ �����Ѵ�.
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
                    //�ݶ��̴��κ��� LivingEntity ������Ʈ ��������
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

    //���� �÷��̾� ������ �Ÿ� ����, �Ÿ��� ���� ���� �޼��� ����
    public virtual void Attack()
    {
        //�ڽ��� ���X, �ֱ� ���� �������� attackDelay �̻� �ð��� ������, �÷��̾���� �Ÿ��� ���� ��Ÿ��ȿ� �ִٸ� ���� ����
        if (!dead && dist <= attackRange)
        {
            //���� �ݰ� �ȿ� ������ �������� �����.
            canMove = false;
            pathFinder.isStopped = true;
            this.transform.LookAt(targetEntity.transform);

            //���� �����̰� �����ٸ� ���� �ִ� ����
            if (lastAttackTime + attackDelay <= Time.time)
            {
                canAttack = true;
                lastAttackTime = Time.time; //�ֱ� ���ݽð� �ʱ�ȭ
                ShamanFire();
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
            //���� ����� ���� && ���� ����� ���� �ݰ� �ۿ� ���� ���, ��θ� �����ϰ� AI �̵��� ��� ����
            canMove = true;
            canAttack = false;
            pathFinder.isStopped = false; //��� �̵�
            pathFinder.SetDestination(targetEntity.transform.position);
        }
    }

    //����Ƽ �ִϸ��̼� �̺�Ʈ�� �����̸� ������ �ֵθ� �� �޼��� ����
    public void ShamanFire()
    {
        magicMissile = Instantiate(magicMissilePrefab, firePoint.transform.position, firePoint.transform.rotation); //Instatiate()�� ���� �̻��� �������� ���� �����Ѵ�.
    }

    /*�̻��Ͽ��� ������ ó���ϱ�
    
    //����Ƽ �ִϸ��̼� �̺�Ʈ�� �ֵθ� �� ������ �����Ű��
    public void OnDamageEvent()
    {
        //������ LivingEntity Ÿ�� ��������
        LivingEntity attackTarget = targetEntity.GetComponent<LivingEntity>();

        //���� ó��
        attackTarget.OnDamage(damage);
    }
    */


    //�������� �Ծ��� �� ������ ó��
    public override void OnDamage(float damage)
    {
        /*������� ���� ���¿����� �ǰ� ȿ�� ���
        if (!dead)
        {
            //���� ���� ������ �������� �ǰ� ȿ�� ���
            hitEffect.transform.position = hitPoint;
            hitEffect.transform.rotation = Quaternion.LookRotation(hitNormal);
            hitEffect.Play();

            //�ǰ� ȿ���� ���
            enemyAudioPlayer.PlayOnShot(hitSound);
        }
        */

        //�ǰ� �ִϸ��̼� ���
        enemyAnimator.SetTrigger("Hit");


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
        enemyAnimator.SetTrigger("Die");
        

    }
}