using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gate : MonoBehaviour
{
    [SerializeField]
    private GameObject _loadingcanvas;
    [SerializeField]
    private Slider _slider;

    private float _progress = 0;

    private void Start()
    {
        _loadingcanvas.SetActive(false);
        _slider.value = _progress;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //hiện lên màng hình loading
                _loadingcanvas.SetActive(true);
            StartCoroutine(LoadScene());          
            
        }
    }


    IEnumerator LoadScene()
    {
       while (_progress < 100)
        {
            _progress += 1;
            _slider.value = _progress;
            yield return new WaitForSeconds(0.1f);
        }
        //chuyên màn chơi
        SceneManager.LoadScene(1);
    }
}
