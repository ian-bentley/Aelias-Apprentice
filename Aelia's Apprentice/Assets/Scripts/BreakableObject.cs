using UnityEngine;

public class BreakableObject : MonoBehaviour, IDamageable
{
    public void TakeDamage()
    {
        Debug.Log(gameObject + ": I am breaking");
    }
}
