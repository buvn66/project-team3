using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI ScoreText;
    public Image FillBar;
    public TextMeshProUGUI ValueText;
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
    public void UpdateBar(int currentValue, int MaxValue)
    {
        FillBar.fillAmount = (float)currentValue / (float)MaxValue;
        ValueText.text = currentValue.ToString() + "/" + MaxValue.ToString();
    }
}
