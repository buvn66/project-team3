using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Knight : MonoBehaviour
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

    public UnityEvent bossKilledEvent;


    void Update()
    {       
        var currentPosition = transform.localPosition;
        if (currentPosition.x > rightBoundary)
        {

            _isMovingRight = false;

        }
        else if (currentPosition.x < leftBoundary)
        {
 
            _isMovingRight = true;
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
    }   
}
