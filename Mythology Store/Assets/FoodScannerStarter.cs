using UnityEngine;

public class FoodScannerStarter : Minigame
{
    private FoodScannerManager foodManager;

    new void Start()
    {
        base.Start();
        foodManager = FindFirstObjectByType<FoodScannerManager>();
        // Spawn items
        foodManager.SpawnFood(GameManager.Instance.foodToScan);

        // Move Camera


    }

    protected override bool HasWon()
    {
        return foodManager.foodScanned >= GameManager.Instance.foodToScan.Count;
    }
}
