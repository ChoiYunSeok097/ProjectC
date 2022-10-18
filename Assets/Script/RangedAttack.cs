using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float time = animator.gameObject.GetComponent<CharacterManager>().time;
        time -= 2f;
        animator.gameObject.GetComponent<CharacterManager>().time = time;
        float Attack = animator.gameObject.GetComponent<CharacterManager>().Attack;
        //투사체 생성
        GameObject obj = Resources.Load<GameObject>("Weapons/Arrow");
        GameObject arrow = Instantiate<GameObject>(obj, animator.transform, true);
        arrow.GetComponent<WeaponAttack>().Attack = Attack;
        arrow.GetComponent<WeaponAttack>().enemy = animator.gameObject.GetComponent<CharacterManager>().enemyManager;
        arrow.transform.position = animator.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("AniIndex", 0);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("CanAttack", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
