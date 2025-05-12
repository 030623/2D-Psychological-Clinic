using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static SaveData saveData;
    public static void Save(string path, SaveData data,int saveIndex)
    {
        
        string jsonData = JsonUtility.ToJson(data);

        if (!Directory.Exists(Application.persistentDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath);
        }
        File.WriteAllText(path+saveIndex+".json", jsonData);

        Debug.Log("Game saved to file!");
    }
    public static void Load(string path , int saveIndex)
    {
        // Load game data from file
        if (File.Exists(path + saveIndex + ".json"))
        {
            string jsonData = File.ReadAllText(path);
            object data = JsonUtility.FromJson(jsonData, typeof(object));
            Debug.Log("Game loaded from file!");
        }
        else
        {
            Debug.Log("No save file found!");
        }
    }
}
