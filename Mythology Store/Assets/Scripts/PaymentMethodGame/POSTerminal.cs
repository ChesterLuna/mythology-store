using UnityEngine;

public class POSTerminal : MonoBehaviour
{

    [SerializeField] AudioClip beepSound;
    [SerializeField] GameObject clipPlayer;

    public void ScanCard(ScannableCard card)
    {
        
        card.ScanCard();
        Instantiate(clipPlayer).GetComponent<AudioSource>().PlayOneShot(beepSound);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ScannableCard card;
        if (collision.TryGetComponent<ScannableCard>(out card))
        {
            ScanCard(card);
            Debug.Log("card read");
            
        }

    }
}
