using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class SaveUIGrid : MonoBehaviour
{
    public TextMeshProUGUI saveNameText , saveTimeText;

    //public SaveData saveData;

    public Button button;

    //public void SetSaveData(SaveData saveData)
    //{
    //    this.saveData = saveData;
    //}
    public int saveIndex = 0;
    private void Start()
    {
        button.onClick.AddListener(()=>SaveManager.Instance.SetSaveIndex(saveIndex));
        button.onClick.AddListener(()=>GameManager.Instance.LoadGame());
    }
}
