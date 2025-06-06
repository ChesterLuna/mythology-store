using UnityEngine;
using UnityEngine.Events;

// Define the different ways a card can behave.
public enum CardType { PIN_Credit, ID_Card, Uno_Reverse }

[RequireComponent(typeof(CardHover))]
public class ScannableCard : MonoBehaviour
{
    
    public CardType type;
    
    public string pinCode = "1234";

    public GameObject pinPadUI;
    public UnityEvent OnCorrectPinEntered;

    private bool transactionComplete = false;
    private CardHover cardHover;

    void Awake()
    {
        cardHover = GetComponent<CardHover>();
    }

    // This is the main method called by the POSTerminal when the card is detected.
    public void ProcessCard(POSTerminal terminal)
    {
        // Ignore if already being processed or finished
        if (transactionComplete || (cardHover != null && cardHover.lockedForPinEntry)) return;

        // Lock the card in place for the duration of the interaction3
        cardHover.lockedForPinEntry = true;

        // --- The card now determines its own reaction ---
        switch (type)
        {
            case CardType.PIN_Credit:
                Debug.Log("PIN required.");
                terminal.DisplayMessage("Enter PIN");
                InitiatePinEntry();
                break;

            case CardType.ID_Card:
                Debug.Log("ID Card Verified.");
                terminal.DisplayMessage("ID Verified");
                CompleteTransaction(); 
                break;

            case CardType.Uno_Reverse:
                Debug.Log("Reverse Payment... THIEF");
                terminal.DisplayMessage("UNO REVERSE!");
                CompleteTransaction();
                break;
        }
    }

    // This private method handles the specific case of needing a PIN
    private void InitiatePinEntry()
    {
        if (pinPadUI != null)
        {
            pinPadUI.SetActive(true);
            PinPad pad = pinPadUI.GetComponent<PinPad>();
            if (pad != null)
            {
                pad.Initialize(this);
            }
        }
    }

    // Call this when the interaction is finished (PIN correct, tap approved, etc.)
    public void CompleteTransaction()
    {
        Debug.Log("Interaction complete.");
        transactionComplete = true;
        OnCorrectPinEntered.Invoke();
        pinPadUI.SetActive(false);
        cardHover.ReturnToWallet();
    }

    // Call this to cancel a PIN entry
    public void ResetScanState()
    {
        pinPadUI.SetActive(false);
        cardHover.ReturnToWallet();
    }
}