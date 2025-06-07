using UnityEngine;
using DialogueEditor;

public class MiniGameStarter : MonoBehaviour
{
    [SerializeField] public GameObject miniGame;
    [SerializeField] public bool hasStartingDialogue;

    private NPCConversation npcConversation;

    [SerializeField] public string miniGameName;

    [SerializeField] AudioClip startingSound;
    [SerializeField] GameObject clipPlayer;

    void Start()
    {
        if (hasStartingDialogue)
        {
            npcConversation = GetComponentInChildren<NPCConversation>();
        }
    }

    public void StartMiniGame()
    {
        if (hasStartingDialogue && npcConversation != null)
        {
            ConversationManager.Instance.StartConversation(npcConversation);
            if (startingSound != null && clipPlayer != null)
            {
                Instantiate(clipPlayer).GetComponent<AudioSource>().PlayOneShot(startingSound);

            }
            GameManager.Instance.DisableList();
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

        GameManager.Instance.SwitchMusicToMini();

        Transform mainCanvas = GameObject.Find("Main Canvas").transform;
        GameObject _miniGameInstance = Instantiate(miniGame, mainCanvas);
        _miniGameInstance.GetComponent<Minigame>().miniGameName = miniGameName;

        if (hasStartingDialogue)
        {
            ConversationManager.OnConversationEnded -= SpawnMiniGame;
        }

    }


}
