using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // Delegate for responding to successful hitbox collisions
    public delegate void HitboxHitDelegate(Collider2D hitboxCollider);

    // Event to be invoked when a hurtbox is hit
    public HitboxHitDelegate hitboxHit;

    // Tracks GameObjects hit during this frame to prevent multiple triggers
    private HashSet<GameObject> hitThisFrame = new HashSet<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Exit early if we've already hit this object this frame
        if (hitThisFrame.Contains(collision.gameObject)) return;

        // Will only interact with hurtboxes
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hurtbox"))
        {
            // Tracks that this object has been hit this frame
            hitThisFrame.Add(collision.gameObject);

            // Warns if no method is subscribed to the hitboxHit delegate
            if (hitboxHit == null)
                Debug.LogWarning("Hitbox triggered but no listener is attached to hitboxHit.");

            // Send out hitboxHit event with the collision source
            hitboxHit?.Invoke(collision);

            //Debug.Log(gameObject + ": I have hit something");
        }
    }

    private void LateUpdate()
    {
        // Clear hit tracking for the next frame
        hitThisFrame.Clear();
    }
}
