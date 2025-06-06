using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PinPad : MonoBehaviour
{
    [SerializeField] private TMP_Text pinDisplayText;
    [SerializeField] private Button[] numberButtons; // assign buttons 0-9
    [SerializeField] private Button enterButton;
    [SerializeField] private Button clearButton;
    [SerializeField] private Button RemoveCard;

    [SerializeField] private int maxPinLength = 4;

    private string currentPin = "";
    private ScannableCard currentCard;
    CardHover cardHover;

    void Awake()
    {
        // listeners for control buttons
        for (int i = 0; i < numberButtons.Length; i++)
        {
            string digit = numberButtons[i].name;
            numberButtons[i].onClick.AddListener(() => AddDigit(digit));
        }
        enterButton.onClick.AddListener(CheckPin);
        clearButton.onClick.AddListener(ClearPin);
        clearButton.onClick.AddListener(ReturnToWalletBridge);
    }
    void ReturnToWalletBridge()
    {
        cardHover.ReturnToWallet();
    }
    // Called by ScannableCard to prepare the pad for a new transaction
    public void Initialize(ScannableCard card)
    {
        currentCard = card;
        ClearPin();
    }
    public void CancelTransaction()
    {
        currentCard.ResetScanState();
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
        if (currentCard != null && currentPin == currentCard.pinCode)
        {
            currentCard.CompleteTransaction();
        }
        else
        {
            Debug.Log("Incorrect PIN...");
            pinDisplayText.text = new string("Incorrect PIN...");
            // add feedback here, like a red flash
            ClearPin();
        }
    }

    private void UpdateDisplay()
    {
        if (pinDisplayText != null)
        {
            // Display asterisks
            pinDisplayText.text = new string('*', currentPin.Length);
        }
    }
}