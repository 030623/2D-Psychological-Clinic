using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    public float delayTime = 2f;
    public List<DelayObject> delayObjects = new List<DelayObject>();
    [System.Serializable]
    public struct DelayObject
    {
        public GameObject obj;
        public bool isToActive;
    }
    private void OnDisable()
    {
        Invoke(nameof(ActivateOrHideObjects), delayTime);
    }

    private void ActivateOrHideObjects()
    {
        // 遍历要激活的物体数组
        Debug.Log("Activate Objects");
        foreach (var obj in delayObjects)
        {
            obj.obj.SetActive(obj.isToActive);
        }
    }
}
