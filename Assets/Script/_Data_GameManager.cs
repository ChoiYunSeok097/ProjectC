using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    public _InGame_SkillCoolTime[] skillButton;      //SkillButton

    _Data_Character nextCharSkill;
    Sprite nextSkillIcon;

    void Start()
    {
        // call characters and waves
        charList = new List<GameObject>();
        wavePosList = new List<Transform[]>();
        wavePosList.Add(wavePos1);
        wavePosList.Add(wavePos2);
        wavePosList.Add(wavePos3);

        // creat characters and wave
        _Data_InstanceManager.instance.instanceList();
        _Data_InstanceManager.instance.player = player;
        _Data_InstanceManager.instance.createParty(player.transform, playerPos, charList);                              //create Party in file
        _Data_InstanceManager.instance.createWaves(MonsterParent.transform, wavePosList, _Data_StageManager.waves);

        randomSkill(charList);
        //Debug.Log(nextCharSkill.transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        // camera move
        camera.cameraPosition(charList);
    }

    void randomSkill(List<GameObject> _charList)
    {
        
        List<string> iconList = _Data_DataInput.instance.loadFile("Party.csv");
        int random = -1,tmp = 0;
        
        if (charList.Count >= 4) random = Random.Range(0, charList.Count);
        Debug.Log(random);
        for (int i = 0; i < charList.Count; i++)
        {
            if (i == random)
            {
                nextCharSkill = _charList[i].GetComponent<_Data_Character>();
                nextSkillIcon = Resources.Load<Sprite>("Image/" + iconList[i]);
                tmp++;
            }
            else
            {
                skillButton[i-tmp].character = charList[i].GetComponent<_Data_Character>();
                skillButton[i - tmp].image.sprite = Resources.Load<Sprite>("Image/" + iconList[i]);
            }
            Debug.Log(charList[i].transform.name);
        }
    }

    public _Data_Character ChangeSkill(_Data_Character _character, _InGame_SkillCoolTime _button)
    {
        if (charList.Count < 4)
        {
            return _character;
        }
       
        _Data_Character tmpCharSkill = nextCharSkill;
        Sprite tmpSkillIcon = nextSkillIcon;

        nextCharSkill = _character;
        nextSkillIcon = _button.image.sprite;

        _button.image.sprite = tmpSkillIcon;
        return tmpCharSkill;
        
    }
}
