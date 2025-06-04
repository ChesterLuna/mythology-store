using UnityEngine;
using System.Collections;

public class CardHover : MonoBehaviour
{
    // Target positions for the cards.
    public Transform revealPosition, walletPosition, payPosition;

    public float slideSpeed = 20f;
    private bool shouldSlide = false;

    

    public enum CardPosition { Wallet, Revealed, Pay };
    public CardPosition currentPosition = CardPosition.Wallet;

    void Start()
    {
        SnapToCurrentPosition();
    }

    void Update()
    {
        if (shouldSlide)
        {
            Vector2 destinationPosition;
            switch (currentPosition)
            {
                case CardPosition.Revealed:
                    destinationPosition = revealPosition.position;
                    break;
                case CardPosition.Pay:
                    destinationPosition = payPosition.position;
                    break;
                case CardPosition.Wallet:
                    destinationPosition = walletPosition.position;
                    break;
                default:
                    shouldSlide = false;
                    return;
            }
            // Move
            transform.position = Vector2.MoveTowards(transform.position, destinationPosition, slideSpeed * Time.deltaTime);
            // check if card reached destination
            if (Vector2.Distance(transform.position, destinationPosition) < 0.01f)
            {
                transform.position = destinationPosition;
                shouldSlide = false;
            }
        }
    }
    void OnMouseDown()
    {
        //ignore input if card is sliding
        if (shouldSlide)
        {
            return;
        }
        // determine next position and update
        switch (currentPosition)
        {
            case CardPosition.Wallet:
                currentPosition = CardPosition.Revealed;
                break;
            case CardPosition.Revealed:
                currentPosition = CardPosition.Pay;
                break;
            case CardPosition.Pay:
                currentPosition = CardPosition.Wallet;
                break;
        }
        shouldSlide = true;
    }
    void SnapToCurrentPosition()
    {
        switch (currentPosition)
        {
            case CardPosition.Wallet:
                if (walletPosition) transform.position = walletPosition.position;
                break;
            case CardPosition.Revealed:
                if (revealPosition) transform.position = revealPosition.position;
                break;
            case CardPosition.Pay:
                if (payPosition) transform.position = payPosition.position;
                break;
            
        }
    }

}