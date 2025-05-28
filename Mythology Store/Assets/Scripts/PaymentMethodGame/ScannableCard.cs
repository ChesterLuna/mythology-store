using UnityEngine;

public class ScannableCard : MonoBehaviour
{
    [SerializeField] public bool scanned = false;
    [SerializeField] public bool hasMinigame = false;
    [SerializeField] public GameObject minigame;



    public void ScanCard()
    {
        scanned = true;

        if (hasMinigame)
        {
            // Instantiate MiniGame
        }
    }
}