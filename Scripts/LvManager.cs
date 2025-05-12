using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvManager : MonoBehaviour
{
    public bool isDialogActived = false;

    public DialogueManager dialogueManager;

    public DialogueEntry dialogueEntry;

    public Sprite sprite;

    SaveGetter saveGetter;
    public void Start()
    {
        if (!isDialogActived)
        {
            dialogueManager.StartDialogue(dialogueEntry);
            dialogueManager.SetSprite(sprite);
            isDialogActived = true;
        }
    }
    private void Awake()
    {
        saveGetter = GetComponent<SaveGetter>();
        //isDialogActived = saveGetter.GetboolData();
    }
}
