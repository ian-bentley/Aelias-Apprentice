using System.Collections.Generic;
using UnityEngine;

public class HitResponder : MonoBehaviour
{
    // Reference to the Hitbox component used for detecting hits
    private Hitbox Hitbox { get; set; }

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
        Debug.Log(gameObject + ": My hitbox has hit something");

        // If the hitbox collider object is damageable, have it take damage
        IDamageable damageable = hitboxCollider.GetComponentInParent<IDamageable>();
        if (damageable != null && doesDamage)
        {
            damageable.TakeDamage();
        }
        else
            Debug.Log(hitboxCollider.gameObject + " was not damaged");
    }
}
