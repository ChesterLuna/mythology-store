using UnityEngine;
using UnityEngine.Events;

public enum CardType { PIN_Credit, ID_Card, Uno_Reverse }

[RequireComponent(typeof(CardHover))]
public class ScannableCard : MonoBehaviour
{
    public CardType type;
    public GameObject pinPadUI;

    private bool transactionComplete = false;
    private CardHover cardHover;
    private POSTerminal terminal;

    void Awake()
    {
        cardHover = GetComponent<CardHover>();
    }

    public void ProcessCard(POSTerminal callingTerminal)
    {
        if (!transactionComplete)
        {
            this.terminal = callingTerminal;
            cardHover.lockedForPinEntry = true;

            switch (type)
            {
                case CardType.PIN_Credit:
                    InitiatePinEntry();
                    break;

                case CardType.ID_Card:
                    // CHANGE: Get text from TextUpdater
                    terminal.DisplayMessage(TextUpdater.Instance.idVerified);
                    CompleteTransaction(false); // No beep/delay needed for simple verification
                    break;

                case CardType.Uno_Reverse:
                    // CHANGE: Get text from TextUpdater
                    terminal.DisplayMessage(TextUpdater.Instance.unoReverseMessage);
                    CompleteTransaction(true);
                    break;
            }
        }
    }

    private void InitiatePinEntry()
    {
        if (pinPadUI != null && terminal != null)
        {
            // CHANGE: Get text from TextUpdater
            terminal.DisplayMessage(TextUpdater.Instance.enterPin);
            pinPadUI.SetActive(true);
            PinPad pad = pinPadUI.GetComponent<PinPad>();
            if (pad != null)
            {
                pad.Initialize(this, this.terminal);
            }
        }
    }

    public void CompleteTransaction(bool playSoundAndDelay = true)
    {
        transactionComplete = true;

        if (pinPadUI != null)
        {
            pinPadUI.SetActive(false);
        }

        // CHANGE: Get text from TextUpdater
        terminal.DisplayMessage(TextUpdater.Instance.transactionCompleteMessage);

        if (playSoundAndDelay)
        {
            terminal.PlayBeep();
        }
        
        // The card can now be returned
        cardHover.lockedForPinEntry = false;
    }

    public void ResetScanState()
    {
        if (pinPadUI != null)
        {
            pinPadUI.SetActive(false);
        }
        // CHANGE: Reset terminal text when card is removed prematurely
        if(terminal != null)
        {
            terminal.DisplayMessage(TextUpdater.Instance.insertCard);
        }
        cardHover.ReturnToWallet();
    }
}