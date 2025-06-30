using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference to the Rigidbody2D for movement
    Rigidbody2D Rb { get; set; }

    // Speed of the player in units per second
    float Speed { get; set; }

    // Normalized direction the projectile moves in
    Vector2 InputDirection { get; set; }

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();

        if (Rb == null)
            Debug.LogError(gameObject + " needs a RigidBody2D component");

        Speed = 3f;
    }

    void Update()
    {
        // Get WASD or arrow key input as a normalized vector
        InputDirection = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
    }

    private void FixedUpdate()
    {
        Move(InputDirection);
    }

    private void Move(Vector2 inputDirection)
    {
        // Move the player forward based on direction and speed
        Rb.MovePosition(Rb.position + inputDirection * Speed * Time.fixedDeltaTime);
    }
}
