using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public Vector3 moveInput;

    private Animator animator;

    public float dashBoost = 2f;
    private float dashTime;
    public float DashTime;
    private bool once;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        transform.position += moveSpeed * Time.deltaTime * moveInput;



        if (moveInput.x != 0)
        {
            if (moveInput.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 0);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 0);
            }
        }
    }
}
