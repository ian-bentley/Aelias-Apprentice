using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public void OnInteract(Interactor interactor)
    {
        // Get the player of the interactor if it exists
        Player player = interactor.gameObject.GetComponentInParent<Player>();
        if (player == null)
        {
            // Log error when Player component is not found and exit
            Debug.LogError(interactor.gameObject + " needs a Player component in parent");
            return;
        }

        // Check if player has a key
        if (player.HasKey)
        {
            // Unlock door
            Debug.Log("Door has been unlocked");

            // Remove key from player and exit
            player.HasKey = false;
            return;
        }

        // If player does not have the key, remain locked
        Debug.Log("Door is locked");
    }
}
