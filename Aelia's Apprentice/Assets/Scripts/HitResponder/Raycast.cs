using UnityEngine;

public class Raycast : HitResponder
{
    [SerializeField] private float rayDistance = 5f;

    protected override void Start()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Hurtbox");

        Debug.DrawRay(transform.position, transform.right * rayDistance, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, rayDistance, layerMask);

        if (hit.collider != null)
        {
            HandleHit(hit.collider);
        }
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.right * rayDistance, Color.red);
    }
}
