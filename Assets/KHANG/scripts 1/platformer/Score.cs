using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{


    [SerializeField]
    private GameObject _achievementCanvas;


    [SerializeField]
    private TextMeshProUGUI _highText;

    [SerializeField]
    private TextMeshProUGUI _curentscore;

    GameData _gameData; 
    Playercontrols _playercontrols; 
    
    private void Start()
    {
        _playercontrols = FindObjectOfType<Playercontrols>();
        _achievementCanvas.SetActive(false);
    }

    // sau khi giết boss 
    //đọc dữ liệu từ file
    //hiển thị điểm thành tích
    //ghi dữ liệu vào file 
    void Update()
    {
        // bấm phim s 
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            ReadDataFromFile();
            ShowData();
            WriteDataTofile();
        }
    }
    void ReadDataFromFile()
    {
        //đọc dữ liệu từ file 
        _gameData = DataManager.ReadData();
        if (_gameData == null)
        {
            _gameData = new GameData()
            {
                score = 0,
                time = 999999
            };

        }

    }
    void ShowData()
    {
        //hiển thị dử liệu lên màng hình
        var score = _playercontrols.GetScore(); //điểm hiện tại 

        var maxScore = Mathf.Max(score, _gameData.score); //điêm lớn nhất

        _highText.text = $"High crore: { maxScore }";
        _curentscore.text = $"curentscore: {score}";

        //hiển thị 
        _achievementCanvas.SetActive(true);

        //cập nhật
        _gameData.score = maxScore;
    }
    void WriteDataTofile ()
    {
        //ghi dử  liệu vào  file 
        DataManager.SaveData(_gameData);   
    }
}
