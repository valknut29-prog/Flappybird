using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/DialogueData")]
public class DialogueData : ScriptableObject
{
    [TextArea(3,6)]
        public string npcText;
        public AnswerData[] answers;
        
}
[System.Serializable]
public class AnswerData
{
    public string text;
    public DialogueData nextDialogue;
}
