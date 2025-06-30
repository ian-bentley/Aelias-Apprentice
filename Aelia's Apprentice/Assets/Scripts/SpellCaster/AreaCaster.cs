using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class AreaCaster : SpellCaster
{
    Vector2 SpawnPos => Player.Instance.gameObject.transform.position;

    Quaternion Rotation => Quaternion.identity;

    GameObject Source => Player.Instance.gameObject;

    public AreaCaster(GameObject spellPrefab) : base(spellPrefab){ }

    public override void CastSpell()
    {
        GameObject areaObj = GameObject.Instantiate(SpellPrefab, SpawnPos, Rotation);

        // Assign the source
        Hitbox hitbox = areaObj.GetComponentInChildren<Hitbox>();
        if (hitbox != null)
            hitbox.Source = Source;
    }
}
