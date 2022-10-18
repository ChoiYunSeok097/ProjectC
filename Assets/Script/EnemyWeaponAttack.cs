using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWeaponAttack : MonoBehaviour
{
    public float Attack;
    public CharacterManager enemy;
    float speed;
    NavMeshAgent pathFinder;
    Vector3 Pos;
    void Awake()
    {
        speed = 10f;
        pathFinder = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            Pos = enemy.transform.position;
            pathFinder.isStopped = false;
            pathFinder.speed = speed;
            pathFinder.SetDestination(Pos);
        }
        if(enemy == null)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == enemy.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
