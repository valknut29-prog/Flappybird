using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] GameObject dialoguePanel;
    [SerializeField] Text npcText;
    [SerializeField] Button[] answerButtons;
    DialogueData currentDialogue;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void StartDialogue(DialogueData dialogue)
    {
        Time.timeScale = 0f;

        currentDialogue = dialogue;
        dialoguePanel.SetActive(true);

        npcText.text = dialogue.npcText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].onClick.RemoveAllListeners();

            if (i < dialogue.answers.Length)
            {
                answerButtons[i].gameObject.SetActive(true);
                answerButtons[i]
                    .GetComponentInChildren<Text>()
                    .text = dialogue.answers[i].text;

                int index = i;
                answerButtons[i].onClick.AddListener(() => ChooseAnswer(index));
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void ChooseAnswer(int index)
    {
        
        if (index < 0 || index >= currentDialogue.answers.Length)
        {
            Debug.LogWarning("Invalid answer index: " + index);
            return;
        }
        AnswerData answer = currentDialogue.answers[index];

        if (answer.nextDialogue != null)
        {
            StartDialogue(answer.nextDialogue);
        }
        else
        {
            EndDialogue();
        }
    }
    

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        Time.timeScale = 1f;
        currentDialogue = null;
    }
}