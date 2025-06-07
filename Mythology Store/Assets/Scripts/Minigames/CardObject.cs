using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class CardObject : MonoBehaviour
{
    [SerializeField] public CardInfo cardInfo;
    [SerializeField] public bool cardMatched = false;

    public CardManager cardManager;

    [SerializeField] private Image objectImage;
    [SerializeField] public Image backImage;

    public Sprite backSprite = null;

    public void Show()
    {
        Tween.Rotation(GetComponent<RectTransform>(), new Vector3(0f, 180f, 0f), 0.2f);
        Tween.Delay(0.1f, () => objectImage.sprite = cardInfo.frontSprite);
        Tween.Delay(0.1f, () => backImage.sprite = cardInfo.frontPaperSprite);
    }

    public void Hide()
    {
        Tween.Rotation(GetComponent<RectTransform>(), new Vector3(0f, 0f, 0f), 0.1f);
        Tween.Delay(0.05f, () => objectImage.sprite = cardInfo.transparentSprite);

        if (backSprite == null)
        {
            Tween.Delay(0.05f, () => backImage.sprite = cardInfo.backSprite);
        }
        else
        {
            Tween.Delay(0.05f, () => backImage.sprite = backSprite);
        }
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
