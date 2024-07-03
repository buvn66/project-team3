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
    public SpriteRenderer characterSR;

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
        //di chuyển
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        transform.position += moveSpeed * Time.deltaTime * moveInput;

        //animation
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        //dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTime <= 0)
        {
            animator.SetBool("Dash", true);
            moveSpeed += dashBoost;
            dashTime = DashTime;
            once = true;
        }

        if (dashTime <= 0 && once)
        {
            animator.SetBool("Dash", false);
            moveSpeed -= dashBoost;
            once = false;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }

        if (moveInput.x != 0)
        {
            if (moveInput.x < 0)
            {
                characterSR.transform.localScale = new Vector3(-1, 1, 0);
            }
            else
            {
                characterSR.transform.localScale = new Vector3(1, 1, 0);
            }
        }
    }
}
