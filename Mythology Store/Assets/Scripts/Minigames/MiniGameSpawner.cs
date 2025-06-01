using System.Collections.Generic;
using System.Linq;
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

        SpawnRandomTasks(difficultyLevel);

        SpawnEmptyTasks();

    }

    private void SpawnRandomTasks(int amount)
    {
        List<string> tasksToSpawn = ShuffleList(miniGamesDict.Keys.ToList<string>());
        for (int i = 0; i < amount; i++)
        {
            MiniGameContainer taskToSpawn = miniGamesDict[tasksToSpawn[i]];
            SpawnTask(taskToSpawn.miniGameName, taskToSpawn.toDoListLine);
        }
    }

    private void SpawnEmptyTasks()
    {
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
            miniGamesDict[taskName].gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Spawned empty task");
        }
    }

    //From https://www.wayline.io/blog/how-to-shuffle-a-list-in-unity but modified to be generic
    public static List<T> ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        return list;
    }
}
