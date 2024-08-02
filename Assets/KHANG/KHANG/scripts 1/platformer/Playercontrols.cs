using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using System;

public class Playercontrols : MonoBehaviour
{


    [SerializeField] //SerializeField cho phép chỉnh sửa tr edit
    public float movespeed = 5f;

    // giá tri lực nhẩy
    [SerializeField]
    private float _jumpForce = 40f;

    //kiểm tra hướng duy  chuyển của nhân vật 
    private bool isMovingRight = true;

    //tham chiếu tới rigibody 2D        
    private Rigidbody2D _rigidbody2D;

    //tham chiếu tới BoxCollider2D
    private BoxCollider2D _boxCollider2D;

    //hàm start dùng để khởi tạo các  giá trị của biến 
    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
      
    }


    //dùng để cập nhật trạ thái của đối tượng dựa trên thời ggian thật  
    private void Update()
    {
        Move();
        Jump();
    }


    private void Move()
    {
        //"horizantalInput" lắng nghe các phim A,D,LEFT,RIGHT.
        //(0) là không nhấn nút,(letf) là số âm, (right) là số dương.

        var horizontalInput = Input.GetAxis("Horizontal");
        //điều khiên phải trái 
        //"+=" là lấy trá tri bang đâu + ra một giá trị mới
        transform.localPosition += new Vector3(horizontalInput, 0, 0)
            * movespeed * Time.deltaTime;
        //transform quản lý thuộc tính
        //localPosition là vị trí tương đối so với cha
        //position vị trí 
        //rotation xuây
        //scale phóng to thu nhỏ hình
        if (horizontalInput > 0)
        {
            //qua phải 
            isMovingRight = true;
        }
        else if (horizontalInput < 0)
        {
            //qua trái 
            isMovingRight = false;
        }

        //xoay nhân vật 
        transform.localScale = isMovingRight ?
            new Vector2(1f, 1f)
            : new Vector2(-1f, 1);
    }


    //hàm sử lý jump
    private void Jump()
    {
        //kiểm tra nhân vật còn trên mặt đất hay không
        var Check = _boxCollider2D.IsTouchingLayers(LayerMask.GetMask("ground"));
        if (Check == false)
        {
            return;
        }
        var verticalInput = Input.GetAxis("Jump");
        if (verticalInput > 0)
        {
            //1. tạo lực nhảy lên trên.
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce));
            //_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }

    }
}
