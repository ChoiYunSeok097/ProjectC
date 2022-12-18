using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class _Data_GameManager : MonoBehaviour
{
    public GameObject MonsterParent,player, throwObjects;     //parent object
    public GameObject uiWin, uiLose;
    List<GameObject> charList;

    public Transform[] playerPos;                // players Position
    public Transform[] wavePos1;
    public Transform[] wavePos2;
    public Transform[] wavePos3;
    public Transform bossPos;
    List<Transform[]> wavePosList;
    public new _InGame_Camera camera;

    public _InGame_SkillCoolTime[] skillButton;      //SkillButton

    public _Data_Character nextCharSkill;
    public Sprite nextSkillIcon;

    public int alivePlayers, aliveEnemy;

    void Start()
    {
        Time.timeScale = 1;

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

        if (_Data_StageManager.boss.name != null)
        {
            _Data_InstanceManager.instance.createMob(MonsterParent.transform, bossPos.position, _Data_StageManager.boss);
        }

        // set parent throw items
        _Data_InstanceManager.instance.throwObjects = throwObjects;

        // set character count
        alivePlayers = charList.Count;
        aliveEnemy = 12;
        if (_Data_StageManager.boss.name != null) aliveEnemy++;

        randomSkill(charList);
        //Debug.Log(nextCharSkill.transform.name);

        //camera = Camera.main.GetComponent<_InGame_Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // camera move
        camera.cameraPosition(charList);
 
    }

    public void discountPlayer()
    {
        alivePlayers--;
        if (alivePlayers == 0)
        {
            uiLose.SetActive(true);
        }
    }

    public void discountEnemy()
    {
        aliveEnemy--;
        if (aliveEnemy == 0)
        {
            uiWin.SetActive(true);
        }
    }

    void randomSkill(List<GameObject> _charList)
    {
        
        List<string> iconList = _Data_DataInput.instance.loadFile("Party.csv");         // load party
        int random = -1,tmp = 0;
        
        if (charList.Count >= 4) random = Random.Range(0, charList.Count);              // if party == 4 characters
        
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
                charList[i].GetComponent<_Data_Character>().skillBtn = skillButton[i - tmp];
            }
        }
    }

    public _Data_Character ChangeSkill(_Data_Character _character, _InGame_SkillCoolTime _button)
    {  
        if(nextCharSkill == null)
        {
            return _character;
        }
        else if (!nextCharSkill.gameObject.activeSelf)
        {
            return _character;
        }
        else if(nextCharSkill.gameObject.activeSelf)
        {

            _Data_Character curCharSkill = nextCharSkill;
            Sprite curSkillIcon = nextSkillIcon;

            _character.skillBtn = null;                     // remove exit character's skill btn
            nextCharSkill = _character;                     // save next char skill
            nextSkillIcon = _button.image.sprite;

            _button.image.sprite = curSkillIcon;
            curCharSkill.skillBtn = _button;                // set character's skill btn

            return curCharSkill;
        }
        return null;
    }
}
