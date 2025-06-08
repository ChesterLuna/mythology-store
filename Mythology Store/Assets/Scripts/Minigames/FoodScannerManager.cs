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


            float rotation = Random.Range(0, 360);

            Quaternion therotation = new Quaternion(Quaternion.identity.x, Quaternion.identity.y, rotation, Quaternion.identity.w);

            Vector3 randomVector = new Vector3(x, y, -2);
            Vector2 spawnPoint = spawner.position + randomVector;
            Instantiate(item, spawnPoint, therotation, foodParent);

        }

    }

}
