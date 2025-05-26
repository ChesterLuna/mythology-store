using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
    [SerializeField] public CardInfo cardInfo;

    private Image image;
    private CardManager cardManager;

    void Start()
    {
        image = GetComponentInChildren<Image>();
        cardManager = FindFirstObjectByType<CardManager>();
        Hide();
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
