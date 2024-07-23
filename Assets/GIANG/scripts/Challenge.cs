using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Challenge : MonoBehaviour
{
    public int requiredEnemies = 10; // Số lượng quái cần tiêu diệt
    private int currentEnemies = 0; // Số lượng quái đã tiêu diệt

    public TMP_Text enemyCountText; // Reference đến TextMeshProUGUI để hiển thị số lượng quái
    public GameObject completionCanvas; // Reference đến GameObject Canvas chứa thông báo hoàn thành

    void Start()
    {
        UpdateEnemyCountUI(); // Cập nhật hiển thị ban đầu
        HideCompletionCanvas(); // Ẩn Canvas thông báo hoàn thành ban đầu
    }

    // Phương thức này được gọi khi một quái bị tiêu diệt
    public void EnemyDestroyed()
    {
        currentEnemies++;
        UpdateEnemyCountUI();

        // Kiểm tra nếu đã tiêu diệt đủ số lượng quái cần thiết
        if (currentEnemies >= requiredEnemies)
        {
            Debug.Log("Nhiệm vụ hoàn thành!");
            ShowCompletionCanvas(); // Hiển thị Canvas thông báo hoàn thành
        }
    }

    // Cập nhật TextMeshProUGUI hiển thị số lượng quái đã tiêu diệt
    private void UpdateEnemyCountUI()
    {
        enemyCountText.text = "Số quái đã tiêu diệt: " + currentEnemies.ToString() + " / " + requiredEnemies.ToString();
    }

    // Hiển thị Canvas thông báo hoàn thành
    private void ShowCompletionCanvas()
    {
        completionCanvas.SetActive(true);
        Invoke("HideCompletionCanvas", 3f); // Sau 3 giây, gọi phương thức HideCompletionCanvas để tắt Canvas
    }

    // Ẩn Canvas thông báo hoàn thành
    private void HideCompletionCanvas()
    {
        completionCanvas.SetActive(false);
    }
}
