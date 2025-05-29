using UnityEngine;
using DialogueEditor;

public class DialogueStarter : MonoBehaviour
{
    private NPCConversation npcConversation;

    void Start()
    {
        npcConversation = GetComponent<NPCConversation>();
    }

    public void StartDialogue()
    {
        ConversationManager.Instance.StartConversation(npcConversation);
    }

}
