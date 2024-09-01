using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance; // 싱글톤 패턴

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // JSON 데이터를 파일로 저장하는 메서드
    public void SaveJsonData(string jsonData, string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, jsonData);
        Debug.Log("Data saved to: " + path);
    }
}
