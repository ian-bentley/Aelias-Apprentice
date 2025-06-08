using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Reference to the Rigidbody2D for movement
    private Rigidbody2D Rb { get; set; }

    // Reference to the Hitbox component used for detecting hits
    private Hitbox Hitbox { get; set; }

    // Direction the projectile moves in
    public Vector2 Direction { get; set; }

    // Speed of the projectile in units per second
    private float Speed { get; set; }

    // Tracks whether the projectile has already hit something
    private bool HasHit { get; set; } = false;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();

        if (Rb == null)
            Debug.LogError(gameObject + " needs a RigidBody2D component");

        Direction = Vector2.up;
        Speed = 5f;

        Hitbox = GetComponentInChildren<Hitbox>();

        // If this does have a hitbox, subscribe to its hitboxHit
        if (Hitbox != null)
            Hitbox.hitboxHit += OnHit;
        else
            Debug.LogError(gameObject + " needs a Hitbox component");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the projectile forward based on direction and speed
        Rb.MovePosition(Rb.position + Direction * Speed * Time.fixedDeltaTime);
    }

    private void OnHit(Collider2D hitboxCollider)
    {
        // Exit early if this has already hit something, otherwise set that it has hit
        if (HasHit) return;
        HasHit = true;

        Debug.Log(gameObject + ": My hitbox has hit something");

        Enemy enemy = hitboxCollider.gameObject.GetComponentInParent<Enemy>();
        enemy.TakeDamage();
    }
}
