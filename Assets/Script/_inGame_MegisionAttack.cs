using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _inGame_MegisionAttack : StateMachineBehaviour
{
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        _Data_Character player = animator.gameObject.GetComponent<_Data_Character>();
        Debug.Log(player.throwItem);
        ThrowWeapon(player.throwItem, player.targetEnemy, animator.gameObject.GetComponent<_Data_Character>());
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

    void ThrowWeapon(GameObject _weapon, GameObject _enemy, _Data_Character _player)
    {
        GameObject weapon = GameObject.Instantiate<GameObject>(_weapon);
        _InGame_ThrowItem _throwItem = weapon.AddComponent<_InGame_ThrowItem>();
        _throwItem.setEnemy(_enemy, _player.transform.position, _player.attack);
    }
}
