using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D Rb { get; set; }
    public Vector2 Direction { get; set; }
    private float Speed { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Direction = Vector2.up;
        Speed = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rb.MovePosition(Rb.position + Direction * Speed * Time.fixedDeltaTime);
    }
}
