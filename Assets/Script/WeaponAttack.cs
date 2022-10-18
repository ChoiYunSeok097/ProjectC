using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WeaponAttack : MonoBehaviour
{
    public float Attack;
    public EnemyManager enemy;
    float speed;
    NavMeshAgent pathFinder;
    void Awake()
    {
        speed = 8f;
        pathFinder = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
            pathFinder.isStopped = false;
            pathFinder.SetDestination(enemy.transform.position);
        }
        if(enemy == null)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
