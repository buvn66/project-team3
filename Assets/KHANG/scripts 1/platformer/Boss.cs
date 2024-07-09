using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    //máu của Boss 
    private float _health = 100;

    [SerializeField]
    private Slider _healthSlider;
    //hiệu ứng nổ 
    [SerializeField]
    private ParticleSystem _explosionPS;

    private void Start()
    {
        _healthSlider.value = _health;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            //hủy viên đạn 
            Destroy(other.gameObject);
            //mổi lần trung bullet -10 máu của boss  
            _health -= 10;
            _healthSlider.value = _health;
            if (_health <= 0)
            {
                //tạo hiệu ứng nổi
                var particleSystem = Instantiate(_explosionPS, gameObject.transform.localPosition, Quaternion.identity);
                //"Instantiate" tạo ra hiệu ứng nổ "_explosionPS" ở vị trí
                //"gameObject.transform.localPosition" có xuây

                Destroy(gameObject);
            }
        }
    }
}
