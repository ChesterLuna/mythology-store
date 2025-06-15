using UnityEngine;
using DialogueEditor;

public class DialogueOnStart : MonoBehaviour
{
    private NPCConversation conversation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        conversation = GetComponentInChildren<NPCConversation>();
        ConversationManager.Instance.StartConversation(conversation);
    }

}
