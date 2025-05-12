using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveAndHide : MonoBehaviour
{
    [Header("�����弤��ʱ")]
    public List<GameObject> activeObjectsToHide;
    public List<GameObject> activeObjectsToActive;
    public UnityEvent onActive;

    [Header("������ʧЧʱ")]
    public List<GameObject> inactiveObjectsToHide;
    public List<GameObject> inactiveObjectsToActive;
    public UnityEvent onInactive;
    private void OnEnable()
    {
        foreach (GameObject obj in activeObjectsToHide)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in activeObjectsToActive)
        {
            obj.SetActive(true);    
        }
        onActive.Invoke();
    }

    private void OnDisable()
    {
        foreach (GameObject obj in inactiveObjectsToHide)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in inactiveObjectsToActive)
        {
            obj.SetActive(true);
        }
        onInactive.Invoke();
    }
}
