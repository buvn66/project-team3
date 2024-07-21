using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using System;

public class PlayerPlatform : MonoBehaviour
{
    [SerializeField] //SerializeField cho phép chỉnh sửa tr edit
    public float movespeed = 5f;


    // giá tri lực nhẩy
    [SerializeField]
    private float _jumpForce = 40f;


    //kiểm tra hướng duy chuyển của nhân vật 
    private bool isMovingRight = true;


    //tham chiếu tới rigibody 2D        
    private Rigidbody2D _rigibody2D;


    //tham chiếu tới BoxCollider2D
    private BoxCollider2D _boxCollider2D;

    //tham chiếu tới animator
    private Animator _animator;
    private bool _canDoubleJum = false;
    [SerializeField]
    //private GameObject _gameOverpanel;
    private static int _lives = 3;
    //[SerializeField]
    //private TextMeshProUGUI _livesText;
    [SerializeField]
    private GameObject[] _liveImages;
    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigibody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //for (int i = 0; i < 3; i++)
        //{
        //    if (i < _lives)
        //    {
        //        _liveImages[i].SetActive(true);
        //    }
        //    else
        //    {
        //        _liveImages[i].SetActive(false);
        //    }
        //}
    }
    private void Update()
    {
        Move();
        Jump();
        FlipSprite();
    }
    private void Move()
    {
        // lay gia tri trung ngang left, right, a, d
        var horizontalInput = Input.GetAxis("Horizontal");
        transform.localPosition += new Vector3(horizontalInput, 0, 0)
                                      * movespeed * Time.deltaTime;
        if (horizontalInput > 0)
        {
            isMovingRight = true;
            _animator.SetBool("IsRun", true);

        }
        else if (horizontalInput < 0)
        {
            isMovingRight = false;
            _animator.SetBool("IsRun", true);
        }
        else
        {
            _animator.SetBool("IsRun", false);
        }
    }
    private void Jump()
    {
        if (_boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Platform")))
        {
            _canDoubleJum = true; // reset laij khi player cham dat 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Platform")) || _canDoubleJum)
            {
                _rigibody2D.velocity = new Vector2(_rigibody2D.velocity.x, _jumpForce);
                if (!_boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Platform")))
                {
                    _canDoubleJum = false; // Use double jump
                }
            }
        }
    }
    private void FlipSprite()
    {
        transform.localScale = isMovingRight ?
        new Vector2(1f, 1f) : new Vector2(-1f, 1f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //bat su kien Player cham spikes
            //mat 1 mang va reload lai man choi
            _lives -= 1;
            // xoa di 1 anh
            //for (int i = 0; i < 3; i++)
            //{
            //    if (i < _lives)
            //    {
            //        _liveImages[i].SetActive(true);
            //    }
            //    else
            //    {
            //        _liveImages[i].SetActive(false);
            //    }

            //}
            if (_lives < 1)
            {
                //Hien ra thong bao GameOver
               // _gameOverpanel.SetActive(true);
                //Dung game
                Time.timeScale = 0;
            }
            else
            {
                // reload lai man choi hien tai
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else if (other.gameObject.CompareTag("Spikes"))
        {
            //bat su kien Player cham spikes
            //mat 1 mang va reload lai man choi
            _lives -= 1;
            // xoa di 1 anh
            //for (int i = 0; i < 3; i++)
            //{
            //    if (i < _lives)
            //    {
            //        _liveImages[i].SetActive(true);
            //    }
            //    else
            //    {
            //        _liveImages[i].SetActive(false);
            //    }

            //}
            if (_lives < 1)
            {
                //Hien ra thong bao GameOver
                //_gameOverpanel.SetActive(true);
                //Dung game
                Time.timeScale = 0;
            }
            else
            {
                // reload lai man choi hien tai
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }
}

