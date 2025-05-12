using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public bool isOneTimeTrigger = true;
    public DialogueManager dialogueManager;
    public DialogueEntry dialogueEntry;

    private void Start()
    {
        dialogueManager.StartDialogue(dialogueEntry);
    }
}
