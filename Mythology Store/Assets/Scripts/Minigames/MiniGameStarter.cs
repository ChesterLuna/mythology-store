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
        GameObject _miniGameInstance = Instantiate(miniGame);

        // Stop player movement?
    }

}
