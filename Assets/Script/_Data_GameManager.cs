using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Data_GameManager : MonoBehaviour
{
    public GameObject MonsterParent,player;
    //Monster monster;
    //Enemy enemy;

    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _Data_InstanceManager.instance.instanceList();
        _Data_InstanceManager.instance.player = player;

        _Data_InstanceManager.instance.createChar("MC01",player.transform,new Vector3(0,0,0));
        //_Data_ResourseManager.instance.PrintResorces();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // disable mmonster
        if((time += Time.deltaTime) > 0.5f)
        {
            //_Data_InstanceManager.instance.createMonster("Cube",MonsterParent.transform,new Vector3(10,0,0));
            time = 0.0f;
        }
        */


    }
}
