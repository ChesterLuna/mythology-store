using UnityEngine;

public class POSTerminal : MonoBehaviour
{

    [SerializeField] AudioClip beepSound;
    [SerializeField] GameObject clipPlayer;

    // The method must accept a parameter called "paymentMethod" with the data-type "PaymentMethod"
    // enum PaymentMethodList : int
    // {
    //     Credit, Cash, UNOReverse, License
    // }
    // // Create a method called "acceptPayment" that returns the data-type "PaymentStatus" (enum)
    // enum PaymentStatus : int
    // {
    //     Accepted, Rejected,
    // }
    public void ScanCard(ScannableCard card)
    {

        card.ScanCard();
        Instantiate(clipPlayer).GetComponent<AudioSource>().PlayOneShot(beepSound);
    }

    // "Insert, swipe, or tap your card"
    // "Enter PIN"
    // "Remove card"
    // "Select account: [Checking / Savings / Credit]"
    // "Do you want cash back? [Yes / No]"
    // "Enter cash back amount"
    // "Transaction approved"
    // "Transaction declined"
    // "Signature required"
    // "Please wait..."
    // "Thank you"
    public void CreditCard()
    {
        Debug.Log("Payment Accepted");
    }

    public void UnoReverseCard()
    {
        Debug.Log("Reverse Payment... THEIF");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ScannableCard card;
        if (collision.TryGetComponent<ScannableCard>(out card))
        {
            ScanCard(card);
            Debug.Log("card read");

        }
        if (collision.CompareTag("CreditCard"))
        {
            CreditCard();
        }
        else if (collision.CompareTag("UnoReverseCard"))
        {
            UnoReverseCard();
        }
        else
        {
            Debug.Log("Scan Failed");
        }
        

    }
    
    
    /*
    if (player.getPaymentStatus() == PaymentStatus.Accept) 
    { 
    tellPlayer("Your payment was successful");
    }
    */

    // method for Credit card

    // method for Uno Reverse card
    // method for Drivers License

    // 

    // create new classes for each triggerable object? 
    // Ontrigger method on payment machine thingy
    // method to reveal each card (move its position a certain y while mouse is hovering)
    // 
}
