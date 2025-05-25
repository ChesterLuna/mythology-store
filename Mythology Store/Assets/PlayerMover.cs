using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] public float speed = 1f;

    Vector2 movement = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = Vector2.zero;
    }

    void Update()
    {
        rb.linearVelocity = movement * speed * Time.deltaTime;
    }

    public void UpdateMovement(InputAction.CallbackContext callbackContext)
    {
        movement = callbackContext.ReadValue<Vector2>();

    }

}
