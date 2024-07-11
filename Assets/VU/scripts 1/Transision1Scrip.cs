using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transision1Scrip : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerScript.instance.isAttacking)
        {
            PlayerScript.instance.myAnim.Play("Attack2");
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerScript.instance.isAttacking = false;
    }

}
