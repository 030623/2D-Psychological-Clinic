using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayHide : MonoBehaviour
{
    public float delay = 5f;

    private void Start()
    {
        Invoke(nameof(Hide), delay);
    }
    void Hide()
    {
        gameObject.SetActive(false);
    }
}
