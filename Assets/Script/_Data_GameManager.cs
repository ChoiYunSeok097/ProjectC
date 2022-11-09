using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Data_GameManager : MonoBehaviour
{
    public GameObject MonsterParent,player;     //parent object
    List<GameObject> charList;
    public Transform[] playerPos;                // players Position
    public Transform[] wavePos1;
    public Transform[] wavePos2;
    public Transform[] wavePos3;
    List<Transform[]> wavePosList;
    public _InGame_Camera camera;

    void Start()
    {
        charList = new List<GameObject>();
        wavePosList = new List<Transform[]>();
        wavePosList.Add(wavePos1);
        wavePosList.Add(wavePos2);
        wavePosList.Add(wavePos3);

        _Data_InstanceManager.instance.instanceList();
        _Data_InstanceManager.instance.player = player;
        _Data_InstanceManager.instance.createParty(player.transform, playerPos, charList);     //create Party in file
        _Data_InstanceManager.instance.createWaves(MonsterParent.transform, wavePosList, _Data_StageManager.waves);
        
        //_Data_ResourseManager.instance.PrintResorces();


    }

    // Update is called once per frame
    void Update()
    {

        // camera move
        camera.cameraPosition(charList);
    }


}
