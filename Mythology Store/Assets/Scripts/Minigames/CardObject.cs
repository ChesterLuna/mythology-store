using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class CardObject : MonoBehaviour
{
    [SerializeField] public CardInfo cardInfo;
    [SerializeField] public bool cardMatched = false;

    private Image image;
    public CardManager cardManager;

    void Start()
    {
        image = GetComponentInChildren<Image>();
    }

    public void Show()
    {
        Tween.Rotation(GetComponent<RectTransform>(), new Vector3(0f, 180f, 0f), 0.2f);
        Tween.Delay(0.1f, () => image.sprite = cardInfo.cardSprite);
    }

    public void Hide()
    {
        Tween.Rotation(GetComponent<RectTransform>(), new Vector3(0f, 0f, 0f), 0.1f);
        Tween.Delay(0.05f, () => image.sprite = cardInfo.defaultSprite);
    }

    public void SetSelected()
    {
        if (cardMatched) return;
        Show();
        cardManager.SetSelected(this);
    }

    public void SetMatched(bool matched)
    {
        cardMatched = matched;
    }
}
