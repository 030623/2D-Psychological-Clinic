using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGetter : MonoBehaviour
{
    public string saveId = "";

    protected string key => $"save{SaveManager.Instance.saveIndex}{saveId}";

    //private void Awake()
    //{
    //    if (SaveManager.Instance.isNewGame)
    //    {
    //        enabled = false;
    //        return;
    //    }
    //}

    //public bool GetboolData()
    //{
    //    if (SaveManager.Instance.isNewGame == true) return false;
    //    return PlayerPrefs.GetInt(key) == 1;
    //}
    //public void SetBoolData()
    //{
    //    PlayerPrefs.SetInt(key, GetComponent<LvManager>().isDialogActived ? 1 : 0);
    //}
}
