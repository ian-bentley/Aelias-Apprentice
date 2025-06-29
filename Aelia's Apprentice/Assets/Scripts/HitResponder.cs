using System.Collections.Generic;
using UnityEngine;

public class HitResponder : MonoBehaviour
{
    // Reference to the Hitbox component used for detecting hits
    private Hitbox Hitbox { get; set; }

    // Determines if a hitresponder damages
    [SerializeField] private bool damages = false;
    [SerializeField] private bool freezes = false;
    [SerializeField] private bool moves = false;
    [SerializeField] private bool resizes = false;

    // Only call and override if it is a hitbox responder
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
        HandleHit(hitboxCollider);
    }

    protected void HandleHit(Collider2D hitboxCollider)
    {
        Debug.Log(gameObject + ": I have hit something");

        // If this can damage, attempt to damage the target
        if (damages)
        {
            IDamageable damageable = hitboxCollider.GetComponentInParent<IDamageable>();
            if (damageable != null) damageable.TakeDamage();
            else Debug.Log(hitboxCollider.gameObject + " was not damaged");
        }

        // If this can freeze, attempt to freeze the target
        if (freezes)
        {
            IFreezeable freezeable = hitboxCollider.GetComponentInParent<IFreezeable>();
            if (freezeable != null) freezeable.Freeze();
            else Debug.Log(hitboxCollider.gameObject + " was not frozen");
        }

        // If this can move, attempt to move the target
        if (moves)
        {
            IMoveable moveable = hitboxCollider.GetComponentInParent<IMoveable>();
            if (moveable != null) moveable.ForcedMove();
            else Debug.Log(hitboxCollider.gameObject + " was not moved");
        }

        // If this can resize, attempt to resize the target
        if (resizes)
        {
            ISizeable sizeable = hitboxCollider.GetComponentInParent<ISizeable>();
            if (sizeable != null) sizeable.ChangeSize();
            else Debug.Log(hitboxCollider.gameObject + " was not resized");
        }
    }
}
