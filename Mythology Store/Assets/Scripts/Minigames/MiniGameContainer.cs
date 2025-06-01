using UnityEngine;

public class MiniGameContainer : MonoBehaviour
{
    public string miniGameName;
    public string toDoListLine;
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
    }

}
