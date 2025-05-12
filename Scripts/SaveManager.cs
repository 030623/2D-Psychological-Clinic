using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                //instance = new GameObject("SaveManager").AddComponent<SaveManager>();
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    static SaveManager instance;
    public int saveIndex = 0;
    public bool isNewGame = true;
    public SaveData saves = new SaveData();

    public struct SaveData
    {
        public List<int> saves;
    }
    private void Awake()
    {
        if (Instance!= this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    public void SetSaveIndex(int index)
    {
        saveIndex = index;
    }
    public void Save()
    {
        saves.saves.Add(1);
        SetSaveIndex(saves.saves.Count - 1);
        foreach(var s in GameManager.Instance.saveGetters)
        {
            //s.SetBoolData();
        }
        SaveDataF();
        Debug.Log($"Save{saves.saves.Count}");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Save();
        }
    }
    public void SaveDataF()
    {
        string path = Application.persistentDataPath + "/saves.json";
        string json = JsonUtility.ToJson(saves);

        System.IO.File.WriteAllText(path, json);

        Debug.Log("Saved");

        //打开文件
        System.Diagnostics.Process.Start(path);
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/saves.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            saves = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Loaded");
        }
        else
        {
            Debug.Log("No save file found");
        }
    }
}
