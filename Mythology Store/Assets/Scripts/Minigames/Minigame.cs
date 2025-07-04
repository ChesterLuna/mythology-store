using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    protected bool endedMinigame = false;

    [SerializeField] protected AudioClip winSound;
    [SerializeField] protected GameObject clipPlayer;
    [SerializeField] protected GameObject winScreen;
    [SerializeField] protected bool hasEndingDialogue = true;
    private NPCConversation[] endingDialogues;

    [SerializeField] public string miniGameName;

    [SerializeField] protected GameObject[] productsToGet;

    protected void Start()
    {
        GameManager.Instance.AllowPlayerMovement(false);
        GameManager.Instance.miniGameInProgress = true;

        if (hasEndingDialogue)
        {
            endingDialogues = GetComponentsInChildren<NPCConversation>();
        }
    }

    protected void Update()
    {
        if (HasWon() && !endedMinigame)
        {
            endedMinigame = true;
            StartCoroutine("EndMinigame");
        }

    }

    protected abstract bool HasWon();

    protected IEnumerator EndMinigame()
    {
        // Play Audio
        Instantiate(clipPlayer).GetComponent<AudioSource>().PlayOneShot(winSound);

        // Show winning screen
        Instantiate(winScreen, this.transform);

        Debug.Log("Show Winning Screen");

        yield return new WaitForSeconds(winSound.length);

        GameManager.Instance.FinishedMiniGame(miniGameName);
        GameManager.Instance.miniGameInProgress = false;

        if (productsToGet != null && productsToGet.Length > 0)
        {
            int chosenID = Random.Range(0, productsToGet.Length);
            GameManager.Instance.foodToScan.Add(productsToGet[chosenID]);
        }

        if (hasEndingDialogue && endingDialogues != null)
        {
            int chosenID = Random.Range(0, endingDialogues.Length);
            NPCConversation chosenConversation = endingDialogues[chosenID];
            ConversationManager.Instance.StartConversation(chosenConversation);

            GameManager.Instance.DisableList();
        }
        else
        {
            GameManager.Instance.AllowPlayerMovement(true);
        }

        AudioSource[] audioSources = GameManager.Instance.GetComponents<AudioSource>();

        GameManager.Instance.SwitchMusicToMain();

        BeforeDestroying();

        Destroy(this.gameObject);
    }

    protected virtual void BeforeDestroying()
    {

    }
}
