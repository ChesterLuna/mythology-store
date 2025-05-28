using UnityEngine;
using System.Collections;

public class PaymentMethod : MonoBehaviour
{
    // Bool for mouse pointer is holding card


    // The method must accept a parameter called "paymentMethod" with the data-type "PaymentMethod"
    enum PaymentMethodList : int
    {
        Credit, Cash, UNOReverse, License
    }
    // Create a method called "acceptPayment" that returns the data-type "PaymentStatus" (enum)
    enum PaymentStatus : int
    {
        Accepted, Rejected,
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