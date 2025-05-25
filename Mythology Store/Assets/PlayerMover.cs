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

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed * Time.fixedDeltaTime;
        // rb.AddForce(movement * speed);
        // print(movement * speed);
    }


    public void UpdateMovement(InputAction.CallbackContext callbackContext)
    {
        Vector2 newMovement = callbackContext.ReadValue<Vector2>();

        // Vector2 interpolatedMovement = Vector2.Lerp(movement, newMovement, 0.1f);

        movement = newMovement;

    }

}
