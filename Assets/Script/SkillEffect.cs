using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    GameObject effect;
    GameObject skill;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*public void SwordandShieldEffectOn()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 4f); // enemy of skill range
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if(cols[i].tag == "Enemy")
                {
                    _Data_Enemy enemy = cols[i].gameObject.GetComponent<_Data_Enemy>();
                    float skilldamage = attack * 3; // skilldamage
                    enemy.TakeDemage(skilldamage);
                    //Solo heal
                    float heal = attack * 2;
                    HpHeal(heal);
                    enemy.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3); //enemy damage motion
                    gameObject.GetComponent<Animator>().SetBool("Skill", true); // char skill motion
                }
            }
        }
        effect = Resources.Load<GameObject>("Effect/FantasySun"); // skill effect
        skill = Instantiate<GameObject>(effect); // create
        skill.transform.SetParent(transform, false); 
        skill.transform.position = transform.position;
    }*/

    /*public void SingleSwordEffectOn()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 4f); // enemy of skill range
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if(cols[i].tag == "Enemy")
                {
                    _Data_Enemy enemy = cols[i].gameObject.GetComponent<_Data_Enemy>();
                    float skilldamage = attack * 4; // skilldamage
                    enemy.TakeDemage(skilldamage);
                    enemy.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3); //enemy damage motion
                    gameObject.GetComponent<Animator>().SetBool("Skill", true); // char skill motion
                }
            }
        }
        effect = Resources.Load<GameObject>("Effect/FireSwordEffect"); // skill effect
        skill = Instantiate<GameObject>(effect); // create
        skill.transform.SetParent(transform, false);
        skill.transform.position = gameObject.transform.position + new Vector3(0, 0.7f, 0);
    }*/

    /*public void DoubleSwordEffectOn()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 4f); // enemy of skill range
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if(cols[i].tag == "Enemy")
                {
                    _Data_Enemy enemy = cols[i].gameObject.GetComponent<_Data_Enemy>();
                    float skilldamage = attack * 4; // skilldamage
                    enemy.TakeDemage(skilldamage);
                    enemy.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3); //enemy damage motion
                    gameObject.GetComponent<Animator>().SetBool("Skill", true); // char skill motion
                }
            }
        }
        effect = Resources.Load<GameObject>("Effect/Tornado"); // skill effect
        skill = Instantiate<GameObject>(effect); // create
        skill.transform.SetParent(transform, false);
        skill.transform.position = transform.position;
    }*/

    /*public void DoubleSwordEffectOn()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 4f); // enemy of skill range
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if(cols[i].tag == "Enemy")
                {
                    _Data_Enemy enemy = cols[i].gameObject.GetComponent<_Data_Enemy>();
                    float skilldamage = attack * 5; // skilldamage
                    enemy.TakeDemage(skilldamage);
                    enemy.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3); //enemy damage motion
                    gameObject.GetComponent<Animator>().SetBool("Skill", true); // char skill motion
                }
            }
        }
        effect = Resources.Load<GameObject>("Effect/ShockWave"); // skill effect
        skill = Instantiate<GameObject>(effect); // create
        skill.transform.SetParent(transform, false);
        skill.transform.position = transform.position;
    }*/

    /*public void ArcherEffectOn()
    {
        _Data_Enemy enemy = targetEnemy.GetComponent<_Data_Enemy>();
        float skilldamage = attack * 5; // skilldamage
        enemy.TakeDemage(skilldamage);
        enemy.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3); //enemy damage motion
        gameObject.GetComponent<Animator>().SetBool("Skill", true); // char skill motion               
        effect = Resources.Load<GameObject>("Effect/LigthningState"); // skill effect
        skill = Instantiate<GameObject>(effect); // create
        skill.transform.SetParent(transform, false);
        skill.transform.position = gameObject.transform.position;
    }*/

    /*public void MagicianEffectOn()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 5f); // enemy of skill range
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                 if(cols[i].tag == "Enemy")
                {
                    _Data_Enemy enemy = cols[i].gameObject.GetComponent<_Data_Enemy>();
                    float skilldamage = attack * 5; // skilldamage
                    enemy.TakeDemage(skilldamage);
                    enemy.gameObject.GetComponent<Animator>().SetInteger("AniIndex", 3); //enemy damage motion
                    gameObject.GetComponent<Animator>().SetBool("Skill", true); // char skill motion
                }
            }
        }
        effect = Resources.Load<GameObject>("Effect/MagicCircleExplode"); // skill effect
        skill = Instantiate<GameObject>(effect); // create
        skill.transform.SetParent(transform, false);
        skill.transform.position = targetEnemy.transform.position;
    }*/

    /*public void PristEffectOn()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 10f); // char of skill range
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                 if(cols[i].tag == "Heroes")
                {
                    _Data_Character heroes = cols[i].gameObject.GetComponent<_Data_Character>();
                    float heal = attack * 3; // skilldamage
                    heroes.HpHeal(heal);
                    gameObject.GetComponent<Animator>().SetBool("Skill", true); // char skill motion
                    effect = Resources.Load<GameObject>("Effect/HealEffect"); // skill effect
                    skill = Instantiate<GameObject>(effect); // create
                    skill.transform.SetParent(heroes.transform, false);
                    skill.transform.position = heroes.transform.position;
                }
            }
        }
    }*/
    public void EffectOff()
    {
        Destroy(skill);
    }
    public void SkillOff()
    {
        gameObject.GetComponent<Animator>().SetBool("Skill", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
