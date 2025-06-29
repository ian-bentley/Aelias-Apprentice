using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    // Used for tracking the collider the interactor is in
    private Collider2D InteractableInRange { get; set; }

    void Start()
    {
        
    }

    void Update()
    {
        // If you press the interact button and there is an interactable in range
        if (Input.GetKeyDown(KeyCode.E) && InteractableInRange != null)
        {
            // Find the collider's interactable component and trigger its OnInteract if it exists
            IInteractable interactable = InteractableInRange.GetComponentInParent<IInteractable>();
            if (interactable != null)
                interactable.OnInteract();
            else
                Debug.LogError(InteractableInRange.gameObject + " needs to have an IInteractable component");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if collision was with an interaction hurtbox and if nothing else is alrady tracked
        if (collision.gameObject.layer == LayerMask.NameToLayer("InteractionHurtbox") &&
            InteractableInRange == null)
        {
            // Start tracking the interaction hurtbox source
            InteractableInRange = collision;
            //Debug.Log("I have entered an interaction hurtbox");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If you are exiting the tracked interaction hurtbox
        if (collision = InteractableInRange)
        {
            // Stop tracking the interaction hurtbox source
            InteractableInRange = null;
            //Debug.Log("I have exited an interaction hurtbox");
        }
    }
}
