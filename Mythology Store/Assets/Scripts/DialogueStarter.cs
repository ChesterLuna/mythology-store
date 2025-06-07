using UnityEngine;
using DialogueEditor;

public class DialogueStarter : MonoBehaviour
{
    private NPCConversation[] npcConversations;
    [SerializeField] AudioClip startingSound;
    [SerializeField] GameObject clipPlayer;

    void Start()
    {
        npcConversations = GetComponentsInChildren<NPCConversation>();
    }

    public void StartDialogue()
    {
        int chosenID = Random.Range(0, npcConversations.Length);
        NPCConversation chosenConversation = npcConversations[chosenID];
        ConversationManager.Instance.StartConversation(chosenConversation);

        if (startingSound != null && clipPlayer != null)
        {
            Instantiate(clipPlayer).GetComponent<AudioSource>().PlayOneShot(startingSound);

        }
        GameManager.Instance.DisableList();
    }

}
