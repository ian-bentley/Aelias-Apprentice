using UnityEngine;

public class HitResponder : MonoBehaviour
{
    // Reference to the Hitbox component used for detecting hits
    private Hitbox Hitbox { get; set; }

    // Tracks whether the projectile has already hit something
    private bool HasHit { get; set; } = false;

    // Determines if a hitresponder damages
    [SerializeField] private bool doesDamage = false;

    protected virtual void Start()
    {
        Hitbox = GetComponentInChildren<Hitbox>();

        // If this does have a hitbox, subscribe to its hitboxHit
        if (Hitbox != null)
            Hitbox.hitboxHit += OnHit;
        else
            Debug.LogError(gameObject + " needs a Hitbox component");
    }

    private void OnHit(Collider2D hitboxCollider)
    {
        // Exit early if this has already hit something, otherwise set that it has hit
        if (HasHit) return;
        HasHit = true;

        Debug.Log(gameObject + ": My hitbox has hit something");

        // Gets the enemy component of the object hit
        Enemy enemy = hitboxCollider.gameObject.GetComponentInParent<Enemy>();

        // Tells the enemy to take a hit
        enemy.TakeHit();

        // If this hit responder is set to do damage, tell the enemy to take damage
        if (doesDamage)
            enemy.TakeDamage();
    }
}
