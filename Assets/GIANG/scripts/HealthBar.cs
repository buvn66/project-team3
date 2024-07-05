using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image FillBar;
    public TextMeshProUGUI ValueText;

    public void UpdateBar(int currentValue, int MaxValue)
    {
        FillBar.fillAmount = (float)currentValue / (float)MaxValue;
        ValueText.text = currentValue.ToString() + "/" + MaxValue.ToString();
    }
}
