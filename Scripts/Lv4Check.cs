using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lv4Check : MonoBehaviour
{
    public bool isOneUp = false;

    public bool isTwoUp = false;

    public UnityEvent onTwoUpIn, onNormal;

    public void Check()
    {

    }

    public void In(bool i)
    {
        if (i)
        {
            if (isOneUp)
            {
                isTwoUp = true;
            }
            else
            {
                isOneUp = true;
            }
        }
        else
        {
            isOneUp = false;
            isTwoUp = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(isOneUp && isTwoUp)
            {
                onTwoUpIn.Invoke();
                isOneUp = false;
                isTwoUp = false;
            }
            else
            {
                onNormal.Invoke();
            }
        }
    }
}
