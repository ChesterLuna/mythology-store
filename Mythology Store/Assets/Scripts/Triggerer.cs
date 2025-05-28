using UnityEngine;
using UnityEngine.Events;

public class Triggerer : MonoBehaviour
{
    [SerializeField] public bool playerTrigger = true;
    [SerializeField] public bool destroyOnPlay = false;
    public UnityEvent unityEvent;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerTrigger && collision.CompareTag("Player") || !playerTrigger)
        {
            unityEvent.Invoke();

            // Add the to-do list
            if (destroyOnPlay)
            {
                Destroy(this.gameObject);

            }
        }
    }

}
