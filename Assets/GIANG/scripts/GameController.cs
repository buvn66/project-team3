using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI ScoreText;
    void Start()
    {
        ScoreText.text = score.ToString();
    }
    void Update()
    {
        
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ScoreText.text = score.ToString();
    }
}
