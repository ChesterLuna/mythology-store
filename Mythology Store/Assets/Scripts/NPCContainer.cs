using UnityEngine;

public class NPCContainer : MonoBehaviour
{
    public string NPCName;

    void Awake()
    {
        if (NPCName == null || NPCName == "")
        {
            NPCName = name;
        }

    }

}
