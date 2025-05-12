using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lv2Controller : MonoBehaviour
{
    public bool isInUpDoor = false;
    public GameObject lv4;
    public UnityEvent onLv4Enter,OnNormalEnter;
    public void SetIsInUpDoor(bool value)
    {
        isInUpDoor = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isInUpDoor)
            {
                onLv4Enter.Invoke();
                isInUpDoor = false;
            }
            else
            {
                OnNormalEnter.Invoke();
                isInUpDoor = true;
            }
        }
    }
}
