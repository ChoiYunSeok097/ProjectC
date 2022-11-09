using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    public float startingHealth = 100f; //���� ü��
    public float startingMana = 0f; //���� ����
    public float health { get; protected set; } //���� ü��
    public float mana { get; protected set; } //���� ����
    public bool dead { get; protected set; } //��� ����
    private Animator livingAnimator;
    

    public event Action onDeath; //��� �� �ߵ��� �̺�Ʈ

    //����ü�� Ȱ��ȭ�� �� ���¸� ����
    protected virtual void OnEnable()
    {
        //������� ���� ���·� ����
        dead = false;
        //ü���� ���� ü������ �ʱ�ȭ
        health = startingHealth;
        mana = startingMana;

    }


    //���ظ� �޴� ���
    public virtual void OnDamage(float damage)
    {
        //��������ŭ ü�� ����
        health -= damage;
        Debug.Log("��������");

        //ü���� 0 ���� && ���� ���� �ʾҴٸ� ��� ó�� ����
        if (health <= 0 && !dead)
        {
            Die();
        }
    }
    //��� ó��
    public virtual void Die()
    {
        //onDeath �̺�Ʈ�� ��ϵ� �޼��尡 �ִٸ� ����
        if (onDeath != null)
        {
            onDeath();
        }

        dead = true;
        
    }

}