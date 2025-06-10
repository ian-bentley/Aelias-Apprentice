using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        Debug.Log(gameObject + ": I have been interacted with");
    }
}
