using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject spellPrefab1;
    [SerializeField] private GameObject spellPrefab2;
    [SerializeField] private GameObject spellPrefab3;
    [SerializeField] private GameObject spellPrefab4;

    SpellQueue spellQueue;
    public bool HasKey { get; set; }

    private GameObject InteractorBox { get; set; }

    // Player singleton
    public static Player Instance { get; private set; }

    // Enforce singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        if (spellPrefab1 == null)
            Debug.LogError(gameObject + " needs to have a spell prefab 1");

        if (spellPrefab2 == null)
            Debug.LogError(gameObject + " needs to have a spell prefab 2");

        if (spellPrefab3 == null)
            Debug.LogError(gameObject + " needs to have a spell prefab 3");

        if (spellPrefab4 == null)
            Debug.LogError(gameObject + " needs to have a spell prefab 4");

        spellQueue = new SpellQueue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spellQueue.AddSpell(SpellWord.Fire);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spellQueue.AddSpell(SpellWord.Push);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spellQueue.AddSpell(SpellWord.Size);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            spellQueue.AddSpell(SpellWord.Reverse);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CastSpell();
            spellQueue.ClearQueue();
        }
    }

    void CastSpell()
    {
        // If spell has fire but no ice, create a damage projectile
        if (spellQueue.Contains(SpellWord.Fire) && !spellQueue.Contains(SpellWord.Reverse))
        {
            Vector2 spawnPos = transform.position;
            Vector2 direction = GetMouseDirection();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            GameObject projectileObj = Instantiate(spellPrefab1, spawnPos, rotation);
            projectileObj.GetComponent<Projectile>().Direction = direction;

            // Assign the source
            Hitbox hitbox = projectileObj.GetComponentInChildren<Hitbox>();
            if (hitbox != null)
                hitbox.Source = this.gameObject;

            // Exit early since spell has been cast
            return;
        }

        // If spell contains fire and reverse, create a freeze area
        if (spellQueue.Contains(SpellWord.Fire))
        {
            Vector2 spawnPos = transform.position;
            Quaternion rotation = Quaternion.identity;

            GameObject areaObj = Instantiate(spellPrefab2, spawnPos, rotation);

            // Assign the source
            Hitbox hitbox = areaObj.GetComponentInChildren<Hitbox>();
            if (hitbox != null)
                hitbox.Source = this.gameObject;

            // Exit early since spell has been cast
            return;
        }

        // If spell contains push and no fire, create a push projectile 
        if (spellQueue.Contains(SpellWord.Push))
        {
            Vector2 spawnPos = transform.position;
            Vector2 direction = GetMouseDirection();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            GameObject projectileObj = Instantiate(spellPrefab3, spawnPos, rotation);
            projectileObj.GetComponent<Projectile>().Direction = direction;

            // Assign the source
            Hitbox hitbox = projectileObj.GetComponentInChildren<Hitbox>();
            if (hitbox != null)
                hitbox.Source = this.gameObject;

            // Exit early since spell has been cast
            return;
        }

        // If spell has size and no fire or push, cast a size projectile
        if (spellQueue.Contains(SpellWord.Size))
        {
            Vector2 spawnPos = transform.position;
            Vector2 direction = GetMouseDirection();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            GameObject projectileObj = Instantiate(spellPrefab4, spawnPos, rotation);
            projectileObj.GetComponent<Projectile>().Direction = direction;

            // Assign the source
            Hitbox hitbox = projectileObj.GetComponentInChildren<Hitbox>();
            if (hitbox != null)
                hitbox.Source = this.gameObject;

            // Exit early since spell has been cast
            return;
        }
    }

    Vector2 GetMouseDirection()
    {
        // Get the mouse position in world space (converted to 2D Vector2)
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get the player's position
        Vector2 playerPos = transform.position;

        // Return the normalized direction from player to mouse
        return (mouseWorldPos - playerPos).normalized;
    }

    public void TakeDamage()
    {
        Debug.Log(gameObject + ": I have been damaged");
    }
}
