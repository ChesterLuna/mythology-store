using System;
using UnityEngine;

public class MiniGameContainer : MonoBehaviour
{
    public string miniGameName;
    public string toDoListLine;

    public void SetMiniGameActive()
    {
        GetComponentInChildren<MiniGameStarter>(true).gameObject.SetActive(true);
        GetComponentInChildren<NPCContainer>(true).gameObject.SetActive(false);
    }

    void Awake()
    {
        if (miniGameName == null || miniGameName == "")
        {
            miniGameName = name;
        }
        if (toDoListLine == null || toDoListLine == "")
        {
            toDoListLine = "Get " + miniGameName + ".";
        }

        GetComponentInChildren<MiniGameStarter>(true).miniGameName = miniGameName;
        GetComponentInChildren<MiniGameStarter>(true).gameObject.SetActive(false);
        GetComponentInChildren<NPCContainer>(true).gameObject.SetActive(true);
    }

}
