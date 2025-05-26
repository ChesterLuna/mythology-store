using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] public bool scanned = false;
    [SerializeField] public bool hasMinigame = false;
    [SerializeField] public GameObject minigame;



    public void ScanProduct()
    {
        scanned = true;

        if (hasMinigame)
        {
            // Instantiate MiniGame
        }
    }
}
