using UnityEngine;
using TMPro;
using System.Collections;

public class POSTerminal : MonoBehaviour
{
    [SerializeField] private AudioClip beepSound;
    private AudioSource audioSource;
    [SerializeField] private TMP_Text terminalDisplayText;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        // Set the initial message
        DisplayMessage(TextUpdater.Instance.insertCard);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ScannableCard>(out ScannableCard card))
        {
            // Display processing message
            DisplayMessage(TextUpdater.Instance.processingMessage);
            card.ProcessCard(this); // Delegate the logic to the card
        }
    }

    public void PlayBeep()
    {
        if (beepSound != null)
        {
            audioSource.PlayOneShot(beepSound);
        }
    }

    public void DisplayMessage(string message)
    {
        if (terminalDisplayText != null)
        {
            terminalDisplayText.text = message;
        }
    }
}