using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _InGame_ThrowItem : MonoBehaviour
{
    GameObject enemy;
    Vector3 enemyPos;
    public float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            destroySelf();
        }
        else if (enemy != null)
        {
            enemyPos = enemy.transform.position;
        }
        if(transform.position == enemyPos)
        {
            destroySelf();
        }
        // move to enemy
        else
        {
            transform.LookAt(enemyPos);         // turn to enemy
            transform.position = Vector3.MoveTowards(transform.position, enemyPos, 30f * Time.deltaTime);
        }
    }

    public void setEnemy(GameObject _enemy, Vector3 _position, float _damage)
    {
        damage = _damage;
        transform.position = _position;
        enemy = _enemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            other.GetComponent<_Data_Enemy>().TakeDemage(damage);
            destroySelf();
        }
    }

    void destroySelf()
    {
        gameObject.SetActive(false);
    }
}
