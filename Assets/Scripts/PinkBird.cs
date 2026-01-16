using UnityEngine;

public class PinkBird : MonoBehaviour
{
    [SerializeField] DialogueData startDialogue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.Instance.StartDialogue(startDialogue);
            //gameObject.SetActive(false);
        }
    }
}