using UnityEngine;

public class ProjectileCaster : SpellCaster
{
    Vector2 SpawnPos => Player.Instance.gameObject.transform.position;

    Vector2 Direction => Player.Instance.GetMouseDirection();
    
    float Angle => Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;

    Quaternion Rotation => Quaternion.Euler(0, 0, Angle);

    GameObject Source => Player.Instance.gameObject;

    public ProjectileCaster(GameObject spellPrefab) : base(spellPrefab){ }

    public override void CastSpell()
    {
        GameObject projectileObj = GameObject.Instantiate(SpellPrefab, SpawnPos, Rotation);
        projectileObj.GetComponent<Projectile>().Direction = Direction;

        // Assign the source
        Hitbox hitbox = projectileObj.GetComponentInChildren<Hitbox>();
        if (hitbox != null)
            hitbox.Source = Source;
    }
}
