using UnityEngine;
using UnityEngine.Events;

public class Triggerer : MonoBehaviour
{
    [SerializeField] public bool playerTrigger = true;
    public UnityEvent unityEvent;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            unityEvent.Invoke();

            // Delete triggerer?
        }
    }

}
