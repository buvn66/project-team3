using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using System;
//tên file phải viết hoa chữ cái đâu 
// tên file phải giông với tên class
//tên file ko có dấu cách không có dấu không có ký tự đặt biệt 
public class Playercontrols : MonoBehaviour
{
    //vận tốc chuyển động 
    public float movespeed = 5f; //"5f" là vận tốc chuyển động của nhân vật
    //"public" là hàm có thể truy xuất ở kháp mọi nơi
    //"private" thì chỉ tồn tại trong class
    [SerializeField]
    //"SerializeField" cho phép chính sửa private trong edit
    // Start is called before the first frame update
    // hàm "start" sẽ chạy trước mỗi frame và hàm chi chạy 1 lần duy nhất 
    //hàm start dùng để khỡi tạo các giá trị của các biến 


    //kiềm tra hướng duy chuyển của nhân vật
    private bool isMovingRight = true;


    // tham chiếu dến rigibody 2D
    private Rigidbody2D _rigidbody2D;


    // giá tri lực nhẩy
    [SerializeField]
    private float _jumpForce = 40f;


    //tham chiếu đên collider2D
    private BoxCollider2D _boxCollider2D;


    //tham chiếu tới animator
    private Animator _animator;


    //tham chiếu đến viên đạn
    [SerializeField]
    private GameObject _bulletPrefab;


    //tham chiếu đến súng 
    [SerializeField]
    private Transform _gun;



    //tham chiếu đên file âm thanh
    [SerializeField]
    private AudioClip _coinCollectSXF; //file âm thanh 
    private AudioSource _audioSource; //nguồn âm thanh
    [SerializeField]
    private AudioClip _frie; //nguồn âm thanh của frie 



    //tham chiếu đến TextMeshPro
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    private static int _score = 0;


    //tham  chiếu hiện số mạng 
    [SerializeField]
    private TextMeshProUGUI _livesText;


    //tham chiếu đên panel gameover     
    [SerializeField]
    private GameObject _gameOverpanel;
    private static int _lives = 3;
    [SerializeField]
    private GameObject[] _liveImages;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        //hiên thi điểm
        _scoreText.text = _score.ToString();
    }


    // Update is called once per frame
    //hàm "update" chạy trên từng frame mỗi một frame thì sẻ chạy hàm một lần
    //hàm update sẻ cố chạy max frame


    void Update()
    {
        Move();
        Jump();
        Fire();
    }


    //hàm sữ lý bắn đạn
    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.F))
        //nếu người chơi nhấn phím F
        {
            //tạo ra viên đạn tại vị trí của súng
            var bullet = Instantiate(_bulletPrefab, _gun.position, Quaternion.identity);
            //hàm "Instantiate" hàm có 3 tham số:
            //tham số thứ nhất là ta tạo ra thứ gì vd:_bulletPrefab
            //tham số thứ hai là ta tạo ra ở đâu vị trí nào vd:_gun.position
            //tham số thứ ba là ta có xuây cái hình hay không "Quaternion.identity"
            //hàm Quaternion.identity có nghĩa là không xuây cái gì cả giữ nguyên mẫu


            //cho viên đạn bay theo hướng của nhân vật
            var velocity = new Vector3(50f, 0);
            if (isMovingRight == false)
            {
                velocity.x *= -1;
            }
            bullet.GetComponent<Rigidbody2D>().velocity = velocity;
            //huy viên đạn sao 2s
            Destroy(bullet, 2f);
            //tạo ra âm thạnh cho viện đạn
            _audioSource.PlayOneShot(_frie);

        }
    }


    //hàm "Move" sử lý chuyên đông ngang của nhân vật 
    //thành phần Time.DeltaTime: thời gian giữa hai frame liên tiếp
    //nhầm chuyệt tiêu độ trên lệt giữa các fps
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
            _animator.SetBool("isruning", true);
        }
        else if (horizontalInput < 0)
        {
            //qua trái 
            isMovingRight = false;
            _animator.SetBool("isruning", true);
        }
        else
        {
            //đứng yên 
            _animator.SetBool("isruning", false);
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
        var Check = _boxCollider2D.IsTouchingLayers(LayerMask.GetMask("platform"));
        if (Check == false)
        {
            return;
        }
        var verticalInput = Input.GetAxis("Jump");
        if (verticalInput > 0)
        {
            //1. tạo lực nhảy lên trên.
            //_rigidbody2D.AddForce(new Vector2(0, _jumpForce));
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }
        
    }


    //va chạm với đồng xu  
    //biến mất đồng xu 
    //phát ra tiếng nhạc 
    //hiển thị điểm khi ăn đồng xu 
    //hiển thị số mạng của player 
    // nếu va chạm với enemies
    //hiện ra màng hình gameover
    private void OnTriggerEnter2D(Collider2D other)
    {
        //nếu va chạm với đồng xu 
        if (other.gameObject.CompareTag("coins"))
        {
            //biến mất đồng xu
            Destroy(other.gameObject);
            //phát ra tiếng nhạc
            _audioSource.PlayOneShot(_coinCollectSXF);
            //tăng điêm
            _score += 10;
            //hiểm thị điểm
            _scoreText.text = _score.ToString();
            //hiện thi số mạng của player 
            _livesText.text = _lives.ToString();
            //hiển thị live images
            for (int i = 0;  i < 3; i++)
            {
                if (i < _lives)
                {
                    _liveImages[i].SetActive(true);
                }
                else
                {
                    _liveImages[i].SetActive(false);
                }

            }
        }
        else if (other.gameObject.CompareTag("Enemies"))
        {
            //nếu va cham với Enemies
            _lives -= 1;
            for (int i = 0; i < 3; i++)
            {
                if (i < _lives)
                {
                    _liveImages[i].SetActive(true);
                }
                else
                {
                    _liveImages[i].SetActive(false);
                }

            }
            if (_lives > 0)
            {
                //reload game 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //hiển thi số mạng của player lên 
                _livesText.text = _lives.ToString();
            }
            else
            {
                // hiên panel gameover
                _gameOverpanel.SetActive(true);
                //dừng game 
                Time.timeScale = 0;
            }
        }
    }

    // va chạm với item 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            //lấy vị trí hiện tại 
            StartCoroutine(GoUp(other.gameObject));

        }

        //đi lên một đoạn 
        IEnumerator GoUp(GameObject gameObject)
        {
            //lấy vị trí hiện tại của khối 
            var currentPosition =  gameObject.transform.localPosition;
            //vị trí ban đầu
            var originalPosition = currentPosition;
            while (true)
            {
                currentPosition.y += 0.1f;
                gameObject.transform.localPosition = currentPosition;
                if (currentPosition.y > originalPosition.y + 1)
                {
                    break;
                }
                yield return null;
            }
            StartCoroutine(GoDown(gameObject));
        }
        IEnumerator GoDown(GameObject gameObject)
        {
            //lấy vị trí hiện tại của khối 
            var currentPosition = gameObject.transform.localPosition;
            //vị trí ban đầu
            var originalPosition = currentPosition;
            while (true)
            {
                currentPosition.y -= 0.1f;
                gameObject.transform.localPosition = currentPosition;
                if (currentPosition.y < originalPosition.y - 1)
                {
                    break;
                }
                yield return null;
            }
            //hiện ra itemsecret
            gameObject.transform.GetChild(0).gameObject.SetActive(true); 
            //ẩn đi item hiện tại 
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
           
        }
    }

    public int GetScore()
    {
        return _score;
    }

}
