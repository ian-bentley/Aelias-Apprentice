using UnityEngine;

public abstract class SpellCaster
{
    protected GameObject SpellPrefab { get; set; }

    public SpellCaster(GameObject spellPrefab)
    {
        SpellPrefab = spellPrefab;
    }

    public abstract void CastSpell();
}
