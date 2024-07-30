using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using System;
using UnityEngine.UI;

public class Knights : MonoBehaviour
{
    [SerializeField]
    private float leftBoundary;

    [SerializeField]
    private float rightBoundary;

    [SerializeField]
    private float moveSpeed = 20f;

    [SerializeField]
    private bool _isMovingRight = true;

    //máu của Boss 
    private float _health = 100;

    [SerializeField]
    private Slider _healthSlider;

    //tham chiếu tới animator
    private Animator _animator;


    void Update()
    {       
        var currentPosition = transform.localPosition;
        if (currentPosition.x > rightBoundary)
        {

            _isMovingRight = false;
            _animator.SetBool("isattack", true);
            _animator.SetBool("isattack1", false);

        }
        else if (currentPosition.x < leftBoundary)
        {
 
            _isMovingRight = true;
            _animator.SetBool("isattack",false);
            _animator.SetBool("isattack1", true);

        }       
        var direction = Vector3.right;
        if (_isMovingRight == false)
        {
            direction = Vector3.left;
        }
        transform.Translate(direction * moveSpeed * Time.deltaTime);       
    }
  
    private void Start()
    {
        _healthSlider.value = _health;
        _animator = GetComponent<Animator>();
        
    }   
}
