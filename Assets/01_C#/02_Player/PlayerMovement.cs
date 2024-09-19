using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    [Header("SpaceMovement")]
    public float acceleration = 1.5f;
    public float deceleration = 0.7f;
    public float rotationSpeed = 5f;

    private Vector2 currentVelocity;

    public void Movement(Vector2 moveInput)
    {
        Vector2 moveDirection = moveInput.normalized;

        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }


    public void MovementSpace(Vector2 moveInput)
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

        // if (currentVelocity != Vector2.zero)
        // {
        //     float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg - 90f;

        //     Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        //     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        // }
    }

}
