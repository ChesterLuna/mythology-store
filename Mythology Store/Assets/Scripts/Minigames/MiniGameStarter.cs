using UnityEngine;

public class MiniGameStarter : MonoBehaviour
{
    [SerializeField] public GameObject miniGame;

    public void SpawnMiniGame()
    {
        if (miniGame == null)
        {
            Debug.Log("No minigame to spawn");
            return;
        }

        Transform mainCanvas = GameObject.Find("Main Canvas").transform;
        GameObject _miniGameInstance = Instantiate(miniGame, mainCanvas);

        // Stop player movement?
    }

}
