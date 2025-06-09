using UnityEngine;

public class HitResponder : MonoBehaviour
{
    // Reference to the Hitbox component used for detecting hits
    private Hitbox Hitbox { get; set; }

    // Tracks whether the projectile has already hit something
    private bool HasHit { get; set; } = false;

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

        Enemy enemy = hitboxCollider.gameObject.GetComponentInParent<Enemy>();
        enemy.TakeDamage();
    }
}
