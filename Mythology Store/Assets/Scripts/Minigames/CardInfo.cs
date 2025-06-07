using UnityEngine;

[CreateAssetMenu(fileName = "CardInfo", menuName = "Scriptable Objects/CardInfo")]
public class CardInfo : ScriptableObject
{

    public string cardName = "";
    public Sprite frontSprite = null;
    public Sprite backSprite = null;
    public Sprite transparentSprite = null;
    public Sprite frontPaperSprite = null;

}
