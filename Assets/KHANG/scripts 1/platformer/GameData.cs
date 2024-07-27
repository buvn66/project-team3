using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;




// class này không có ":MonoBehaviour" vì ":MonoBehaviour" dùng để điểu khiển một đối
//tượng nào đó còn không có thì class thường chỉ dùng để chứa dữ liệu thôi 

[Serializable] //"Serializable" dùng để lưu file 
public class GameData 
{
    public int score; //điểm số lớn nhất 
    
    public float time; //điểm số ngắn nhất đã từng chơi 

}

// class dùng để đọc và ghi file 
public class DataManager
{
    const string FILE_NAME = "data.txt";
    //const là hà số thừng đc viết in hoa 

    public static bool SaveData(GameData data)
    {
        try
        {
            var json = JsonUtility.ToJson(data); //chuyễn dữ liệu thành dạng jason = text 
            var fileStream = new FileStream(FILE_NAME, FileMode.Create); //tạo ra một file mới
            using (var writer = new StreamWriter(fileStream)) //mở file để ghi dữ liệu 
            {
                writer.Write(json); //ghi dữ liệu vào file 
            }
            return true; //chạy đc
        }
        catch (Exception e)
        {
            Debug.Log($"Save data error: {e.Message}");
        }
        return false; //chạy có lỗi thì game hog bị dừng 
    }

    public static GameData ReadData()
    {
        try
        {
            if (File.Exists(FILE_NAME)) //kiểm tra file có tồn tại hay không
            {
                var fileStream = new FileStream(FILE_NAME, FileMode.Open);
                using (var reader = new StreamReader(fileStream))
                {
                    var json = reader.ReadToEnd(); //đọc  dững liệu từ file 
                    var data = JsonUtility.FromJson<GameData>(json); //chuyễn dữ liệu từ text sang class
                    return data;
                }
            }            
        }
        catch (System.Exception e)
        {
            Debug.Log("Error loading file:" + e.Message);
        }
        return null;
    }

}
