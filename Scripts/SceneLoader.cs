using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
    public string sceneName = "";
    public int sceneIndex = -1;
    public bool isStartLoad = false;
    private void Start()
    {
        if (isStartLoad)
        {
            if (sceneName.Length > 0)
            {
                LoadScene(sceneName);
            }
            if(sceneIndex > -1)
            {
                LoadScene(sceneIndex);
            }
        }
    }
}
