using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public string manmoi;
    public void loading()
    {
        SceneManager.LoadScene(manmoi);
    }
    private void OnTriggerEnter2D (Collider2D cosision)
    {
        if (cosision.CompareTag("Player"))
        {
            loading();
        }
    }  
}
