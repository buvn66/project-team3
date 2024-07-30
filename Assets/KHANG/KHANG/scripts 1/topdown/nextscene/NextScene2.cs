using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextScene2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(50.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
