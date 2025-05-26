using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
    [SerializeField] public CardInfo cardInfo;

    private Image image;
    public CardManager cardManager;

    void Start()
    {
        image = GetComponentInChildren<Image>();
    }

    public void Show()
    {
        image.sprite = cardInfo.cardSprite;
    }

    public void Hide()
    {
        image.sprite = cardInfo.defaultSprite;
    }

    public void SetSelected()
    {
        Show();
        cardManager.SetSelected(this);
    }
}
