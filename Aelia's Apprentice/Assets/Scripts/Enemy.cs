using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public void TakeDamage()
    {
        Debug.Log(gameObject + ": I have been damaged");
    }
}
