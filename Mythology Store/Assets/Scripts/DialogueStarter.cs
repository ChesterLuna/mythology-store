using UnityEngine;
using DialogueEditor;

public class DialogueStarter : MonoBehaviour
{
    private NPCConversation[] npcConversations;

    void Start()
    {
        npcConversations = GetComponentsInChildren<NPCConversation>();
    }

    public void StartDialogue()
    {
        int chosenID = Random.Range(0, npcConversations.Length);
        NPCConversation chosenConversation = npcConversations[chosenID];
        ConversationManager.Instance.StartConversation(chosenConversation);
        GameManager.Instance.DisableList();
    }

}
