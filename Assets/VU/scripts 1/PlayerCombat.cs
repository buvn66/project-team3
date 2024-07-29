using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    // Update được gọi mỗi frame
    void Update()
    {
        // Kiểm tra nếu phím B được nhấn
        if (Input.GetKeyDown(KeyCode.B))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Phát hoạt cảnh tấn công
        animator.SetTrigger("Attack");
        // Phát hiện enemy trong phạm vi tấn công
        // Gây sát thương cho enemy 
    }
}
