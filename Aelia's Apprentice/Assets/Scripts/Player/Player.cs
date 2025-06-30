using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] SpellRegistry spellRegistry;

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
        // Create a spell caster builder so it can create a new spell caster
        try
        {
            SpellCasterBuilder spellCasterBuilder = new SpellCasterBuilder(spellRegistry);
            SpellCaster spellCaster = spellCasterBuilder.CreateSpellCaster(spellQueue);

            // Cast spell
            spellCaster.CastSpell();
        }
        catch (InvalidSpellException e)
        {
            // If queued spell was not valid
            Debug.Log(e.Message);
        }
    }

    public Vector2 GetMouseDirection()
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
