using DialogueEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private PlayerMover playerMover;

    private void Awake()
    {
        // Make a singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += OnSceneLoaded;
            ConversationManager.OnConversationStarted += StopMovement;
            ConversationManager.OnConversationEnded += AllowMovement;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (playerMover == null)
        {
            playerMover = FindFirstObjectByType<PlayerMover>();
        }
        
    }

    public void AllowPlayerMovement(bool allowMovement)
    {
        if (allowMovement)
        {
            AllowMovement();
        }
        else
        {
            StopMovement();
        }
    }
    public void AllowMovement()
    {
        playerMover.AllowMovement();
    }
    public void StopMovement()
    {
        playerMover.StopMovement();
    }

}
