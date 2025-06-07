using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class FoodScannerManager : MonoBehaviour
{
    public int foodScanned;
    [SerializeField] private Transform spawner;
    [SerializeField] private float spawnArea = 5f;

    [SerializeField] private Transform foodParent;
    [SerializeField] public CinemachineCamera cmCamera;


    public void SpawnFood(List<GameObject> items)
    {
        foreach (GameObject item in items)
        {
            float x = Random.Range(-spawnArea, spawnArea);
            float y = Random.Range(-spawnArea, spawnArea);
            Vector2 randomVector = new Vector2(x, y);
            Vector2 spawnPoint = (Vector2)spawner.position + randomVector;
            Instantiate(item, spawnPoint, Quaternion.identity, foodParent);

        }

    }

}
