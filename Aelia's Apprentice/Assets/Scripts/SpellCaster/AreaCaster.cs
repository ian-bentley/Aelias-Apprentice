using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class AreaCaster : SpellCaster
{
    Vector2 SpawnPos => Player.Instance.gameObject.transform.position;

    Quaternion Rotation => Quaternion.identity;

    GameObject Source => Player.Instance.gameObject;

    readonly float _sizeMult;

    public AreaCaster(GameObject spellPrefab, float sizeMult) : base(spellPrefab)
    { 
        _sizeMult = sizeMult;
    }

    public override void CastSpell()
    {
        GameObject areaObj = GameObject.Instantiate(SpellPrefab, SpawnPos, Rotation);


        areaObj.transform.localScale *= _sizeMult;

        // Assign the source
        Hitbox hitbox = areaObj.GetComponentInChildren<Hitbox>();
        if (hitbox != null)
            hitbox.Source = Source;
    }
}
