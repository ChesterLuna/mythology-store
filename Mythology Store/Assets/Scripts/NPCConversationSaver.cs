using DialogueEditor;
using UnityEngine;

public class NPCConversationSaver : MonoBehaviour
{

    [SerializeField] public string json;
    private NPCConversation npcConversation;

    void Awake()
    {
        npcConversation = GetComponent<NPCConversation>();
        if (json != null)
        {
            npcConversation.json = json;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
