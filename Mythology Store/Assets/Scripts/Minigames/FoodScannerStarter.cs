using System.Collections;
using UnityEngine;

public class FoodScannerStarter : Minigame
{
    private FoodScannerManager foodManager;
    [SerializeField] public CardScannerManager paymentMinigame;

    new void Start()
    {
        base.Start();
        foodManager = FindFirstObjectByType<FoodScannerManager>();
        paymentMinigame = FindFirstObjectByType<CardScannerManager>();
        // Spawn items
        foodManager.SpawnFood(GameManager.Instance.foodToScan);

        // Move Camera
        foodManager.cmCamera.Priority = 2;
    }

    protected override bool HasWon()
    {
        bool won = foodManager.foodScanned >= GameManager.Instance.foodToScan.Count;
        if (won)
        {
        }
        return won;
    }

    protected override void BeforeDestroying()
    {
        foreach (Product item in foodManager.gameObject.GetComponentsInChildren<Product>())
        {
            Destroy(item.gameObject);
        }
        foodManager.cmCamera.Priority = -1;

        paymentMinigame.DelayStart();
    }
}
