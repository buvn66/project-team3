﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hades : MonoBehaviour
{
    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;

    public Slider healthBar;
    public bool isDead;

    private void Start()
    {
        // anim = GetComponent<Animator>(); // Removed
    }

    private void Update()
    {
        if (health <= 25)
        {
            // anim.SetTrigger("stageTwo"); // Removed
        }

        if (health <= 0)
        {
            // anim.SetTrigger("death"); // Removed
        }

        // give the player some time to recover before taking more damage!
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;
    }
}
