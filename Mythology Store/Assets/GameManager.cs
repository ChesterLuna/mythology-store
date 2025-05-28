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
            playerMover.AllowMovement();
        }
        else
        {
            playerMover.StopMovement();
        }
    }

}
