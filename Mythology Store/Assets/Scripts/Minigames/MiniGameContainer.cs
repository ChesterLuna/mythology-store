using System;
using UnityEngine;

public class MiniGameContainer : MonoBehaviour
{
    public string miniGameName;
    public string toDoListLine;

    public void SetMiniGameActive()
    {
        GetComponentInChildren<MiniGameStarter>().gameObject.SetActive(true);
        GetComponentInChildren<NPCContainer>().gameObject.SetActive(false);
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

        GetComponentInChildren<MiniGameStarter>().miniGameName = miniGameName;
        GetComponentInChildren<NPCContainer>().gameObject.SetActive(true);
    }

}
