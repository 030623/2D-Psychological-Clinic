using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/Dialogue Entry")]
public class DialogueEntry : ScriptableObject
{
    public List<Sprite> characterSprites = new List<Sprite>();
    [TableList]
    public List<DialogueNode> nodes = new List<DialogueNode>();
}

[System.Serializable]
public class DialogueNode
{
    [BoxGroup("Indexs")]
    public int index;
    [HideIf("optionType", OptionType.Option)]
    [BoxGroup("Indexs")]
    public int nextIndex = 0;
    [BoxGroup("Indexs")]
    public int characterIndex = 0;
    [HideIf("optionType", OptionType.Option)]
    [TextArea(3, 10)]
    [BoxGroup("Options")]
    public string content;

    [BoxGroup("Options")]
    public OptionType optionType = OptionType.Noraml;
    public enum OptionType
    {
        Noraml, Option, End
    }
    [ShowIf("optionType", OptionType.Option)]
    [BoxGroup("Options")]
    public List<DialogeOption> options = new List<DialogeOption>();

    public AudioClip audioClip;
}
[System.Serializable]
public class DialogeOption
{
    [TextArea(3, 10)]
    public string optionText;
    public int nextIndex;
}