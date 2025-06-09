using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void TakeDamage()
    {
        Debug.Log(gameObject + ": I have been damaged");
    }

    public void TakeHit()
    {
        Debug.Log(gameObject + ": I have been hit");
    }
}
