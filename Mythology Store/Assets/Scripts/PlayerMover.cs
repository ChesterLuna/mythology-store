using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] public float speed = 1f;

    Vector2 movement = Vector2.zero;
    private bool allowMovement = true;

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
        if (!allowMovement) return;

        Vector2 newMovement = callbackContext.ReadValue<Vector2>();

        // Vector2 interpolatedMovement = Vector2.Lerp(movement, newMovement, 0.1f);

        movement = newMovement;

    }

    public void AllowMovement()
    {
        allowMovement = true;
    }

    public void StopMovement()
    {
        allowMovement = false;
        rb.linearVelocity = Vector2.zero;
        movement = Vector2.zero;
    }
}
