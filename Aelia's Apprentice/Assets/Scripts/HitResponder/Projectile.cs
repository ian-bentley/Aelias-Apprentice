using UnityEngine;

public class Projectile : HitResponder
{
    // Reference to the Rigidbody2D for movement
    private Rigidbody2D Rb { get; set; }

    // Direction the projectile moves in
    public Vector2 Direction { get; set; }

    // Base speed of the projectile in units per second
    private float BaseSpeed { get; set; } = 5f;

    // Speed mult of the projectile
    public float SpeedMult { get; set; } = 1f;

    // Speed of the projectile based on base x mult
    private float Speed => BaseSpeed * SpeedMult;

    public float SizeMult { get; set; } = 1f;

    protected override void Start()
    {
        // Call HitResponder.Start() to ensure that setup runs first
        base.Start();

        Rb = GetComponent<Rigidbody2D>();

        if (Rb == null)
            Debug.LogError(gameObject + " needs a RigidBody2D component");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the projectile forward based on direction and speed
        Rb.MovePosition(Rb.position + Direction * Speed * Time.fixedDeltaTime);
    }
}
