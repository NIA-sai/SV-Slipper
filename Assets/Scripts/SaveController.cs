using System.IO;
using Assets.Scripts.Object;
using UnityEngine;

public class SaveController<T>  where T : SaveData
{
    public string fileName;
    private string saveFilePath;

    public void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
    }
    public void SaveSaveData(T saveData)
    {
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Save " + fileName + "Complete");
    }
    public T LoadSaveData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            T saveData = JsonUtility.FromJson<T>(json);
            return saveData;
        }
        else
        {
            Debug.LogWarning("Save file not found, using default position.");
            return null;
        }
    }
}
