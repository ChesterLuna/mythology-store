using UnityEngine;

public class UIButton : MonoBehaviour
{
    public void SwitchDisplay(GameObject gameObject)
    {
        if (gameObject.activeSelf)
        {
            Disable(gameObject);
        }
        else
        {
            Enable(gameObject);
        }

    }
    public void Enable(GameObject gameObject)
    {
        gameObject.SetActive(true);

    }
    public void Disable(GameObject gameObject)
    {
        Debug.Log("Tries to disable");
        gameObject.SetActive(false);
    }
}
