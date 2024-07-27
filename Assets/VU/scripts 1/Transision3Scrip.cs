using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transision3Scrip : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerScript.instance.isAttacking = false;
    }
}
