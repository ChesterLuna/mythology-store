using System;
using System.Collections.Generic;
using DialogueEditor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private PlayerMover playerMover;
    public int difficultyLevel = 2;
    public bool miniGameInProgress = false;
    public bool gamePaused = false;

    [SerializeField] private GameObject listObject;
    

    public Dictionary<string, GameObject> currentTasksDict = new Dictionary<string, GameObject>();
    public List<string> finishedTasks = new List<string>();

    public List<GameObject> foodToScan = new List<GameObject>();

    [SerializeField] private List<GameObject> objectsToEnableAfterList = new List<GameObject>();

    [SerializeField] AudioClip miniGameSound;
    [SerializeField] AudioClip mainGameSound;

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

    public void PauseGame()
    {
        gamePaused = true;
    }

    public void DisableList()
    {
        listObject.SetActive(false);
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

    public void FinishedMiniGame(string miniGameName)
    {
        if (!currentTasksDict.ContainsKey(miniGameName)) return;
        TextMeshProUGUI taskDone = currentTasksDict[miniGameName].GetComponent<TextMeshProUGUI>();
        taskDone.text = "<s>" + taskDone.text + "</s>";
        finishedTasks.Add(miniGameName);

        if (finishedTasks.Count >= difficultyLevel)
        {
            foreach (GameObject item in objectsToEnableAfterList)
            {
                item.SetActive(true);
            }
        }
    }

    public void DestroyManager()
    {
        Destroy(this.gameObject);
        SceneManager.sceneLoaded -= OnSceneLoaded;
        ConversationManager.OnConversationStarted -= StopMovement;
        ConversationManager.OnConversationEnded -= AllowMovement;
    }

    internal void TimeFinished()
    {
        Debug.Log("Game is done");
        GameManager.Instance.DestroyManager();
        SceneManager.LoadScene("LoseGame");
    }

    internal void SwitchMusicToMain()
    {
        GetComponent<AudioSource>().clip = mainGameSound;
        GetComponent<AudioSource>().Play();
    }

    internal void SwitchMusicToMini()
    {
        GetComponent<AudioSource>().clip = miniGameSound;
        GetComponent<AudioSource>().Play();
    }
}
