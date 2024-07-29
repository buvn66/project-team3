using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeScript : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerScript.instance.isAttacking)
        {
            PlayerScript.instance.myAnim.Play("Attack");
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerScript.instance.isAttacking = false;
    }
}
