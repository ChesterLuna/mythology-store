using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PinPad : MonoBehaviour
{
    [SerializeField]
    private Button zero, one, two, three, four, five, six, seven, eight, nine, enterButton, clearButton, RemoveCard;

    [SerializeField] private int maxPinLength = 4;

    private string currentPin = "";
    private ScannableCard currentCard;
    private POSTerminal currentTerminal;

    void Awake()
    {
        enterButton.onClick.AddListener(CheckPin);
        clearButton.onClick.AddListener(ClearPin);
        RemoveCard.onClick.AddListener(ReturnToWalletBridge);
        zero.onClick.AddListener(() => AddDigit("0"));
        one.onClick.AddListener(() => AddDigit("1"));
        two.onClick.AddListener(() => AddDigit("2"));
        three.onClick.AddListener(() => AddDigit("3"));
        four.onClick.AddListener(() => AddDigit("4"));
        five.onClick.AddListener(() => AddDigit("5"));
        six.onClick.AddListener(() => AddDigit("6"));
        seven.onClick.AddListener(() => AddDigit("7"));
        eight.onClick.AddListener(() => AddDigit("8"));
        nine.onClick.AddListener(() => AddDigit("9"));
    }

    void ReturnToWalletBridge()
    {
        if (currentCard != null)
        {
            currentCard.ResetScanState();
        }
    }

    public void Initialize(ScannableCard card, POSTerminal terminal)
    {
        currentCard = card;
        currentTerminal = terminal;
        ClearPin();
    }

    public void AddDigit(string digit)
    {
        if (currentPin.Length < maxPinLength)
        {
            currentPin += digit;
            UpdateDisplay();
        }
    }

    public void ClearPin()
    {
        currentPin = "";
        UpdateDisplay();
    }

    public void CheckPin()
    {
        // Compare against the PIN in TextUpdater.Instance
        if (currentCard != null && currentPin == TextUpdater.Instance.pinCode)
        {
            // The card handles the "complete" message and UI closing
            currentCard.CompleteTransaction();
        }
        else
        {
            // Get text from TextUpdater
            if (currentTerminal != null)
            {
                currentTerminal.DisplayMessage(TextUpdater.Instance.incorrectPin);
            }
            StartCoroutine(WaitThenClear());
        }
    }

    IEnumerator WaitThenClear()
    {
        yield return new WaitForSeconds(1.5f);
        ClearPin();
        
        // After clearing, reset the prompt
        if(currentTerminal != null)
        {
            currentTerminal.DisplayMessage(TextUpdater.Instance.enterPin);
        }
    }

    private void UpdateDisplay()
    {
        if (currentTerminal != null)
        {
            // Display asterisks
            if (currentPin.Length > 0)
            {
                currentTerminal.DisplayMessage(new string('*', currentPin.Length));
            }
            else //show the main prompt again
            {
                currentTerminal.DisplayMessage(TextUpdater.Instance.enterPin);
            }
        }
    }
}