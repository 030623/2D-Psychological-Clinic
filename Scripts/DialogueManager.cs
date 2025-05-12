using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI dialogueText;
    public GameObject optionButtonPrefab;
    public Transform optionsPanel;

    [Header("Settings")]
    public float typingSpeed = 0.05f;

    public UnityEvent onDialogueEnd;

    private DialogueEntry currentDialogue;
    private int currentNodeIndex = -1;
    private Coroutine typingCoroutine;
    private bool isTyping = false;
    private bool waitForInput = false;
    [SerializeField]
    Image background;
    public bool isOnce = true;
    public bool isFirst = true;

    public AudioSource audioSource;
    private void Update()
    {
        if (waitForInput && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            waitForInput = false;
            NextNode();
        }
    }

    public void StartDialogue(DialogueEntry dialogue)
    {
        if (isOnce && !isFirst) return;
        gameObject.SetActive(true);
        currentDialogue = dialogue;
        currentNodeIndex = 0;
        DisplayNode(currentDialogue.nodes[0]);
        Debug.Log("Start Dialogue");
    }

    private void DisplayNode(DialogueNode node)
    {
        ClearOptions();
        Debug.Log(currentDialogue.name);
        SetSprite(currentDialogue.characterSprites[node.characterIndex]);

        switch (node.optionType)
        {
            case DialogueNode.OptionType.Noraml:
            case DialogueNode.OptionType.End:
                if (typingCoroutine != null) StopCoroutine(typingCoroutine);
                typingCoroutine = StartCoroutine(TypeText(node.content));
                break;
            case DialogueNode.OptionType.Option:
                ShowOptions(node.options);
                break;
        }
        audioSource.clip = node.audioClip;
        audioSource.Play();
    }

    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";
        waitForInput = false;

        foreach (char c in text)
        {
            dialogueText.text += c;
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
                yield return null; // 长按跳过
            else
                yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        waitForInput = true;

        // 如果是结束节点，自动结束对话
        if (currentDialogue.nodes[currentNodeIndex].optionType == DialogueNode.OptionType.End)
        {
            yield return new WaitForSeconds(0.5f);
            EndDialogue();
        }
    }

    private void ShowOptions(List<DialogeOption> options)
    {
        foreach (var option in options)
        {
            GameObject buttonObj = Instantiate(optionButtonPrefab, optionsPanel);
            Button button = buttonObj.GetComponent<Button>();
            TextMeshProUGUI text = buttonObj.GetComponentInChildren<TextMeshProUGUI>();

            text.text = option.optionText;
            button.onClick.AddListener(() => SelectOption(option.nextIndex));
        }
    }

    private void SelectOption(int nextIndex)
    {
        currentNodeIndex = nextIndex;
        DisplayNode(currentDialogue.nodes[currentNodeIndex]);
    }

    private void NextNode()
    {
        var currentNode = currentDialogue.nodes[currentNodeIndex];
        if (currentNode.optionType == DialogueNode.OptionType.End) return;

        int nextIndex = currentNode.nextIndex;
        if (nextIndex < 0 || nextIndex >= currentDialogue.nodes.Count)
        {
            EndDialogue();
            return;
        }

        currentNodeIndex = nextIndex;
        DisplayNode(currentDialogue.nodes[currentNodeIndex]);
    }

    private void EndDialogue()
    {
        ClearOptions();
        dialogueText.text = "";
        currentNodeIndex = -1;
        onDialogueEnd.Invoke();
        Debug.Log("End Dialogue");
        audioSource.Stop();
    }

    private void ClearOptions()
    {
        foreach (Transform child in optionsPanel)
        {
            Destroy(child.gameObject);
        }
    }
    public void SetSprite(Sprite sprite)
    {
        if (sprite == null) return;
        background.sprite = sprite;
    }
}