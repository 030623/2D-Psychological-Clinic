using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PasswordLock : MonoBehaviour
{
    public string password = "349";

    public TMP_InputField inputField;

    public UnityEvent onUnlock;

    public static bool isUnlocked = false;

    private void OnEnable()
    {
        inputField.interactable = !isUnlocked;
    }
    private void Update()
    {
        if (inputField.text.Length >= 3)
        {
            if(inputField.text == password)
            {
                //Unlock the door
                Debug.Log("Unlocked!");
                onUnlock.Invoke();
                isUnlocked = true;
            }
            else
            {
                inputField.text = "";
                //Wrong password
                Debug.Log("Wrong password!");
            }
        }
    }
}
