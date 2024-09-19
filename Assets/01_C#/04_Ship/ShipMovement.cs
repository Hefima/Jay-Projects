using UnityEngine;
using UnityEngine.InputSystem;  // Für das neue Input System

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed = 40f;
    public float acceleration = 1.5f;
    public float deceleration = 0.7f;
    public float rotationSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 currentVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ShipMove(Vector2 moveInput)
    {
        Vector2 moveDirection = moveInput.normalized;

        if (moveDirection != Vector2.zero)
        {
            currentVelocity = Vector2.MoveTowards(currentVelocity, moveDirection * moveSpeed, acceleration);
        }
        else
        {
            currentVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, deceleration);
        }

        rb.linearVelocity = currentVelocity;

        if (currentVelocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg - 90f;

            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    public bool ShipStopped()
    {
        if (currentVelocity == Vector2.zero)
            return true;
        else
            return false;
    }
}

