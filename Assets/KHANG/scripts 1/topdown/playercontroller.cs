using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using System;

public class Playercontroller : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private Camera mainCamera;
    public GameObject bulletPrefabs;
    public Transform firePoint;
    public float fireRate = 1.0f;
    private float nextfireTime;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));        
        RotatePlayer();
        if (Input.GetMouseButtonDown(0) && Time.time >= nextfireTime)
        {
            shoot();
            nextfireTime = Time.time + fireRate;

        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSpeed;


    }
   
    void RotatePlayer()
    {
        Vector2 mousePositison = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePositison - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    void shoot()
    {
        Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);

    }
}
