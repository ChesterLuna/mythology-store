using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public bool enabledWhileMinigame = false;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (enabledWhileMinigame && GameManager.Instance.miniGameInProgress)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

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
