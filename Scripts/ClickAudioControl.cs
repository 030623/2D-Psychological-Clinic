using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickAudioControl : MonoBehaviour
{
    Button button;
    public AudioClip audioClip;
    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() => AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position));
    }
}
