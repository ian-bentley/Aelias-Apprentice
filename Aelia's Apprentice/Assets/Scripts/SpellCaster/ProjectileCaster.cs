using UnityEngine;

public class ProjectileCaster : SpellCaster
{
    Vector2 SpawnPos => Player.Instance.gameObject.transform.position;

    Vector2 Direction => Player.Instance.GetMouseDirection();
    
    float Angle => Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;

    Quaternion Rotation => Quaternion.Euler(0, 0, Angle);

    GameObject Source => Player.Instance.gameObject;

    readonly float _speedMult;
    readonly float _sizeMult;

    public ProjectileCaster(GameObject spellPrefab, float speedMult, float sizeMult) : base(spellPrefab)
    { 
        _speedMult = speedMult;
        _sizeMult = sizeMult;
    }

    public override void CastSpell()
    {
        // Instantiate projectile game object
        GameObject projectileObj = GameObject.Instantiate(SpellPrefab, SpawnPos, Rotation);

        // Set reference to projectile object
        Projectile projectile = projectileObj.GetComponent<Projectile>();
        
        // Set projectile direction, speed, and size
        projectile.Direction = Direction;
        projectile.SpeedMult = _speedMult;
        projectileObj.transform.localScale *= _sizeMult;

        // Assign the source
        Hitbox hitbox = projectileObj.GetComponentInChildren<Hitbox>();
        if (hitbox != null)
            hitbox.Source = Source;
    }
}
