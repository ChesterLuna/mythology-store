using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CardHover : MonoBehaviour
{
    // Target positions for the cards.
    public Transform revealPosition, walletPosition, payPosition;
    public float slideSpeed = 20f;
    private bool shouldSlide = false;
    public bool lockedForPinEntry = false;
    public enum CardPosition { Wallet, Revealed, Pay };
    public CardPosition currentPosition = CardPosition.Wallet;

    public static List<CardHover> AllCards = new List<CardHover>();
    public static event Action<CardHover> OnCardInitiatedMove;

    void OnEnable()
    {
        if (!AllCards.Contains(this))
        {
            AllCards.Add(this);
        }
        OnCardInitiatedMove += HandleFocusCardChanged;
    }

    void OnDisable()
    {
        AllCards.Remove(this);
        OnCardInitiatedMove -= HandleFocusCardChanged;
    }

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
                default:
                    destinationPosition = walletPosition.position;
                    break;
            }

            // Move the card
            transform.position = Vector2.MoveTowards(transform.position, destinationPosition, slideSpeed * Time.deltaTime);

            // Check if card reached destination
            if (Vector2.Distance(transform.position, destinationPosition) < 0.01f)
            {
                transform.position = destinationPosition;
                shouldSlide = false;

                // Scan the card when it reaches the pay position ---
                
            }
           
        }
    }

    void OnMouseDown()
    {
        if (shouldSlide || lockedForPinEntry) return;

        CardPosition nextPotentialState = currentPosition;
        switch (currentPosition)
        {
            case CardPosition.Wallet:
                currentPosition = CardPosition.Revealed;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case CardPosition.Revealed:
                currentPosition = CardPosition.Pay;
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case CardPosition.Pay:
                currentPosition = CardPosition.Wallet;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }

        shouldSlide = true;
        if ((nextPotentialState != currentPosition) && OnCardInitiatedMove != null)
        {
            OnCardInitiatedMove.Invoke(this);
        }
    }

    void HandleFocusCardChanged(CardHover cardThatInitiatedMove)
    {
        if (cardThatInitiatedMove != this && !lockedForPinEntry)
        {
            if (currentPosition != CardPosition.Wallet)
            {
                currentPosition = CardPosition.Wallet;
                shouldSlide = true; // Slide back to wallet
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        //if 
    }
    public void ReturnToWallet()
    {
        lockedForPinEntry = false; // Unlock the card
        currentPosition = CardPosition.Wallet;
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