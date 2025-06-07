using UnityEngine;
using TMPro;

public class POSTerminal : MonoBehaviour
{
    [SerializeField] private AudioClip beepSound;
    private AudioSource audioSource;
    [SerializeField] private TMP_Text terminalDisplayText; 

    void Awake()
    {
        // A better way to handle audio playback
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the entering object has a ScannableCard script attached.
        if (collision.TryGetComponent<ScannableCard>(out ScannableCard card))
        {
            PlayBeep();
            DisplayMessage("Processing...");
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
        terminalDisplayText.text = message;
    }
}