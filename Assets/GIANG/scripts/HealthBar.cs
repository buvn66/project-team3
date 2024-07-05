using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image fillBar; // Thanh hình ảnh để hiển thị phần lấp đầy của thanh máu
    public TextMeshProUGUI valueText; // Text để hiển thị giá trị số sức khỏe

    private int currentValue; // Giá trị hiện tại của sức khỏe
    private int maxValue; // Giá trị tối đa của sức khỏe

    // Hàm khởi tạo để gán giá trị tối đa ban đầu cho thanh máu
    public void Initialize(int initialMaxValue)
    {
        maxValue = initialMaxValue;
        currentValue = maxValue; // Khởi tạo giá trị hiện tại bằng giá trị tối đa ban đầu
        UpdateBar();
    }

    // Hàm cập nhật thanh máu
    public void UpdateBar()
    {
        fillBar.fillAmount = (float)currentValue / maxValue;
        valueText.text = currentValue.ToString() + "/" + maxValue.ToString();
    }

    // Hàm giảm giá trị thanh máu khi nhận sát thương
    public void TakeDamage(int damage)
    {
        currentValue -= damage;
        if (currentValue < 0)
        {
            currentValue = 0;
        }
        UpdateBar();
    }

    // Hàm hồi phục giá trị thanh máu
    public void Heal(int amount)
    {
        currentValue += amount;
        if (currentValue > maxValue)
        {
            currentValue = maxValue;
        }
        UpdateBar();
    }
}
