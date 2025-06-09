using UnityEngine;

public class Projectile : HitResponder
{
    // Reference to the Rigidbody2D for movement
    private Rigidbody2D Rb { get; set; }

    // Direction the projectile moves in
    public Vector2 Direction { get; set; }

    // Speed of the projectile in units per second
    private float Speed { get; set; }

    protected override void Start()
    {
        // Call HitResponder.Start() to ensure that setup runs first
        base.Start();

        Rb = GetComponent<Rigidbody2D>();

        if (Rb == null)
            Debug.LogError(gameObject + " needs a RigidBody2D component");

        Direction = Vector2.up;
        Speed = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the projectile forward based on direction and speed
        Rb.MovePosition(Rb.position + Direction * Speed * Time.fixedDeltaTime);
    }
}
