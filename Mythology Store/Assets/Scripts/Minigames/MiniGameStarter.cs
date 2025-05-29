using UnityEngine;
using DialogueEditor;

public class MiniGameStarter : MonoBehaviour
{
    [SerializeField] public GameObject miniGame;
    [SerializeField] public bool hasStartingDialogue;

    private NPCConversation npcConversation;


    void Start()
    {
        if (hasStartingDialogue)
        {
            npcConversation = GetComponent<NPCConversation>();
        }
    }

    public void StartMiniGame()
    {
        if (hasStartingDialogue && npcConversation != null)
        {
            ConversationManager.Instance.StartConversation(npcConversation);
            ConversationManager.OnConversationEnded += SpawnMiniGame;
        }
        else
        {
            SpawnMiniGame();
        }
    }


    public void SpawnMiniGame()
    {
        if (miniGame == null)
        {
            Debug.Log("No minigame to spawn");
            return;
        }


        Transform mainCanvas = GameObject.Find("Main Canvas").transform;
        GameObject _miniGameInstance = Instantiate(miniGame, mainCanvas);

        if (hasStartingDialogue)
        {
            ConversationManager.OnConversationEnded -= SpawnMiniGame;
        }

    }


}
