using UnityEngine;
using DialogueEditor;

public class DialogueStarter : MonoBehaviour
{
    private NPCConversation npcConversation;

    void Start()
    {
        npcConversation = GetComponentInChildren<NPCConversation>();
    }

    public void StartDialogue()
    {
        ConversationManager.Instance.StartConversation(npcConversation);
        GameManager.Instance.DisableList();
    }

}
