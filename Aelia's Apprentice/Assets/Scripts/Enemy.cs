using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IFreezeable, IMoveable, ISizeable
{
    public void ChangeSize()
    {
        Debug.Log(gameObject + ": I have been resized");
    }

    public void ForcedMove()
    {
        Debug.Log(gameObject + ": I have been moved");
    }

    public void Freeze()
    {
        Debug.Log(gameObject + ": I have been frozen");
    }

    public void TakeDamage()
    {
        Debug.Log(gameObject + ": I have been damaged");
    }
}
