using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _InGame_ThrowItem : MonoBehaviour
{
    GameObject enemy;
    

    public _Data_Character character;
    Vector3 enemyPos;
    public float damage = 0;

    // Start is called before the first frame update
    void Awake()
    {
        //collider = gameObject.GetComponent<Collider>();
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

        //HitScan();
    }

    public void setEnemy(GameObject _enemy, Vector3 _position, float _damage)
    {
        damage = _damage;
        transform.position = _position;
        enemy = _enemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other != null)
        {
            if (other.gameObject.tag == character.enemy)
            {
                other.GetComponent<_Data_Character>().TakeDemage(damage);
                destroySelf();
            }
            else
                limitDestroy();
        }
    }

    void HitScan()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 3f);
        Collider collider = new Collider();
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (collider.bounds.Intersects(cols[i].bounds) && cols[i] != collider && cols[i].gameObject.tag == character.enemy)
                    Debug.Log("Ãæµ¹");
            }
        }
    }

    IEnumerator limitDestroy()
    {
        yield return new WaitForSeconds(2.0f);
        if(gameObject.activeSelf)
            destroySelf();
    }

    void destroySelf()
    {
        _Data_InstanceManager.instance.throwItems.Add(this.gameObject);
        gameObject.SetActive(false);
    }
}
