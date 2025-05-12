using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    static GameManager instance;
    public List<SaveGetter> saveGetters = new List<SaveGetter>();
    public int currentSaveIndex => saveScene.Where(x => x.activeSelf).ToList().IndexOf(saveScene.First(x => x.activeSelf));
    public List<GameObject> saveScene = new List<GameObject>();

    private void Awake()
    {
        if(Instance!= this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadGame()
    {
        saveScene[currentSaveIndex].SetActive(true);
    }
    public void NewGame()
    {
        saveScene[0].SetActive(true);
    }
}
