using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameSpawner : MonoBehaviour
{
    private MiniGameContainer[] miniGameContainers;
    private Dictionary<string, MiniGameContainer> miniGamesDict;
    private Dictionary<string, GameObject> tasksDict;
    private int difficultyLevel = 2;

    [Header("List")]
    [SerializeField] private Transform listTransform;
    [SerializeField] private GameObject taskObject;
    [SerializeField] private int minimumListSize = 11;


    void Start()
    {
        miniGamesDict = new Dictionary<string, MiniGameContainer>();
        tasksDict = new Dictionary<string, GameObject>();

        miniGameContainers = GetComponentsInChildren<MiniGameContainer>();

        difficultyLevel = GameManager.Instance.difficultyLevel;

        foreach (MiniGameContainer container in miniGameContainers)
        {
            miniGamesDict.Add(container.miniGameName, container);
            container.gameObject.SetActive(false);
        }

        for (int i = 0; i < difficultyLevel; i++)
        {
            SpawnTask(miniGameContainers[i].miniGameName, miniGameContainers[i].toDoListLine);
        }


        int leftOutTasks = minimumListSize - listTransform.childCount;
        if (leftOutTasks > 0)
        {
            for (int i = 0; i < leftOutTasks; i++)
            {
                SpawnTask("", "");
            }
        }



    }

    public void SpawnTask(string taskName, string taskText)
    {
        GameObject task = Instantiate(taskObject, listTransform);
        task.GetComponent<TextMeshProUGUI>().text = taskText;

        if (taskName != "")
        {
            tasksDict.Add(taskName, task);
        }
        else
        {
            Debug.Log("Spawned empty task");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
