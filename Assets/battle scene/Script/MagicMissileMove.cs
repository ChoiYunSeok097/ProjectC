using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissileMove : MonoBehaviour
{
    public LivingEntity targetEntity;//���� ���

    public float speed = 15f;
    public float hitOffset = 0f;
    public bool UseFirePointRotation;
    public Vector3 rotationOffset = new Vector3(0, 0, 0);
    public GameObject hit;
    public GameObject flash;
    private Rigidbody rb;
    private SphereCollider sphCollider;
    public GameObject[] Detached;
    private float lastCollisionEnterTime;
    private float collisionDealy = 0.1f;

    //���� �̻��� ���� ������, 
    public float damage;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphCollider = GetComponent<SphereCollider>();
        BattleMagic enemyShaman = GameObject.Find("Enemy_Goblin Shaman").GetComponent<BattleMagic>();
        damage = enemyShaman.damage;

        if (flash != null)
        {
            var flashInstance = Instantiate(flash, transform.position, Quaternion.identity); //Quaternion.identity ȸ�� ����
            flashInstance.transform.forward = gameObject.transform.forward;
            var flashPs = flashInstance.GetComponent<ParticleSystem>();
            if (flashPs != null)
            {
                Destroy(flashInstance, flashPs.main.duration);   //ParticleSystem�� main.duration, �⺻ �ð��ε�, duration�� ���� ���� ���� �� ����
            }
            else
            {
                var flashPsParts = flashInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(flashInstance, flashPsParts.main.duration);
            }
        }

        Destroy(gameObject, 5);
    }

    //���� �̻��� �̵� ���
    void FixedUpdate()
    {
        if (speed != 0)
        {
            rb.velocity = transform.forward * speed; //Ÿ���� ����� ���� �� ���� �̻����� �������� ���ư���
        }
    }

    private void Update()
    {
        OnSphereCollider();
    }

    void OnCollisionEnter(Collision collision)  //�����̻����� �浹���� ���
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            speed = 0;

            //������ LivingEntity Ÿ�� ��������, �������� �����ϱ� ���� �غ�
            LivingEntity attackTarget = collision.gameObject.GetComponent<LivingEntity>();

            Debug.Log("�浹�� ������Ʈ�� ���̾�" + collision.gameObject.layer + "�浹�� �ð�" + lastCollisionEnterTime);

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point + contact.normal * hitOffset;

            if (hit != null)
            {
                var hitInstance = Instantiate(hit, pos, rot);
                if (UseFirePointRotation) { hitInstance.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180f, 0); }
                else if (rotationOffset != Vector3.zero) { hitInstance.transform.rotation = Quaternion.Euler(rotationOffset); }
                else { hitInstance.transform.LookAt(contact.point + contact.normal); }

                var hitPs = hitInstance.GetComponent<ParticleSystem>();
                if (hitPs != null)
                {
                    Destroy(hitInstance, hitPs.main.duration);
                }
                else
                {
                    var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(hitInstance, hitPsParts.main.duration);
                }
            }
            foreach (var detachedPrefab in Detached)
            {
                if (detachedPrefab != null)
                {
                    detachedPrefab.transform.parent = null;
                }
            }
            Destroy(gameObject);

            //������ ó��
            attackTarget.OnDamage(damage);
            Debug.Log("���� ������" + damage);
        }

        else if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            speed = 0;

            Debug.Log("�浹�� ������Ʈ�� ���̾�" + collision.gameObject.layer + "�浹�� �ð�" + lastCollisionEnterTime);

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point + contact.normal * hitOffset;

            if (hit != null)
            {
                var hitInstance = Instantiate(hit, pos, rot);
                if (UseFirePointRotation) { hitInstance.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180f, 0); }
                else if (rotationOffset != Vector3.zero) { hitInstance.transform.rotation = Quaternion.Euler(rotationOffset); }
                else { hitInstance.transform.LookAt(contact.point + contact.normal); }

                var hitPs = hitInstance.GetComponent<ParticleSystem>();
                if (hitPs != null)
                {
                    Destroy(hitInstance, hitPs.main.duration);
                }
                else
                {
                    var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(hitInstance, hitPsParts.main.duration);
                }
            }
            foreach (var detachedPrefab in Detached)
            {
                if (detachedPrefab != null)
                {
                    detachedPrefab.transform.parent = null;
                }
            }
            Destroy(gameObject);
        }

        else
        {
            sphCollider.enabled = false;
            Debug.Log("�浹�� ������Ʈ�� ���̾�" + collision.gameObject.layer + "�浹�� �ð�" + lastCollisionEnterTime);
        }
    }

    void OnSphereCollider()
    {
        if (lastCollisionEnterTime + collisionDealy < Time.time)
        {
            sphCollider.enabled = true;
            lastCollisionEnterTime = Time.time;
            Debug.Log("�ݶ��̴� ����");
        }
    }
}