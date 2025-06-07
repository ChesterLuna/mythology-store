using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    public static TextUpdater Instance { get; private set; }

    public string insertCard = "Please Insert Card";
    public string enterPin = "Enter PIN";
    public string processingMessage = "Processing...";
    public string transactionCompleteMessage = "Transaction Complete!";
    public string transactionFailedMessage = "Transaction Failed";
    public string incorrectPin = "Incorrect PIN";
    public string idVerified = "ID Verified";
    public string unoReverseMessage = "UNO REVERSE?! THIEF!";

    public string pinCode = ""; // Set the correct PIN here

    private void Awake()
    {
        // Establish the Singleton instance
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}