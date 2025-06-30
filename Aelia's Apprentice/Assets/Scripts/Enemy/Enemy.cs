using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IFreezeable, IMoveable, ISizeable
{
    // Prefab for enemy's attack
    [SerializeField] private GameObject attackPrefab;

    // Enemy movement speed
    [SerializeField] float speed;

    // Reference to the Rigidbody2D for movement
    Rigidbody2D Rb { get; set; }

    Vector2 movementDir;
    
    // Reference to the player for targeting
    Player player;

    // Attack cooldown timer for deciding when to fire
    Timer attackCooldownTimer;

    void Start()
    {
        player = Player.Instance;
        Rb = GetComponent<Rigidbody2D>();

        if (Rb == null)
            Debug.LogError(gameObject + " needs a RigidBody2D component");

        if (attackPrefab == null)
            Debug.LogError(gameObject + " needs to have an attack prefab");

        // Start movement direction as nothing
        movementDir = Vector2.zero;

        // Sets the attack cooldown timer to 5s
        attackCooldownTimer = new Timer(5f);

        // Start the cooldown
        attackCooldownTimer.Start();
    }

    void Update()
    {
        if (attackCooldownTimer.IsFinished)
        {
            // Attack the player
            Attack();

            // Restart the cooldown
            attackCooldownTimer.Restart();
        }
        attackCooldownTimer.Update(Time.deltaTime);
    }

    void FixedUpdate()
    {
        // Sets the movement direction
        SetMovementDir();

        // Moves the enemy
        Move();
    }

    // Sets the movement direction based on the player
    void SetMovementDir()
    {
        // Sets movement direction to player's direction
        movementDir = GetPlayerDirection();
    }

    void Move()
    {
        // Move the player forward based on direction and speed
        Rb.MovePosition(Rb.position + movementDir * speed * Time.fixedDeltaTime);
    }

    Vector2 GetPlayerDirection()
    {
        // Gets the player position
        Vector2 playerPos = player.gameObject.transform.position;

        // Gets the enemy position
        Vector2 myPos = transform.position;

        // Returns normalize player direction
        return (playerPos - myPos).normalized;
    }

    void Attack()
    {
        // Sets the direction to the player direction
        Vector2 direction = GetPlayerDirection();

        // Sets spawn position to enemy
        Vector2 spawnPos = transform.position;

        // Sets angle of rotation based on direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Sets rotation based on angle
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        // Creates a new projectile at position and rotation
        GameObject projectileObj = Instantiate(attackPrefab, spawnPos, rotation);
        projectileObj.GetComponent<Projectile>().Direction = direction;

        // Assign the source
        Hitbox hitbox = projectileObj.GetComponentInChildren<Hitbox>();
        if (hitbox != null)
            hitbox.Source = this.gameObject;
    }

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
