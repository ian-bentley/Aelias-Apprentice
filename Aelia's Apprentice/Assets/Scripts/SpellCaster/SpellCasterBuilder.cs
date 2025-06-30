using System;
using UnityEngine;

public class SpellCasterBuilder
{
    private readonly SpellRegistry _spellRegistry;

    public SpellCasterBuilder(SpellRegistry spellRegistry)
    {
        _spellRegistry = spellRegistry;
    }

    public SpellCaster CreateSpellCaster(SpellQueue spellQueue)
    {
        // If spell has fire but no ice, create a damage projectile
        if (spellQueue.Contains(SpellWord.Fire) && !spellQueue.Contains(SpellWord.Reverse))
        {
            return new ProjectileCaster(_spellRegistry.GetPrefab(Spell.Fireball));
        }

        // If spell contains fire and reverse, create a freeze area
        if (spellQueue.Contains(SpellWord.Fire))
        {
            return new AreaCaster(_spellRegistry.GetPrefab(Spell.IceField));
        }

        // If spell contains push and no fire, create a push projectile 
        if (spellQueue.Contains(SpellWord.Push))
        {
            return new ProjectileCaster(_spellRegistry.GetPrefab(Spell.Push));
        }

        // If spell has size and no fire or push, cast a size projectile
        if (spellQueue.Contains(SpellWord.Size))
        {
            return new ProjectileCaster(_spellRegistry.GetPrefab(Spell.Grow));
        }

        throw new InvalidSpellException("Spell queue did not have a valid spell. No spell will be cast.");
    }
}
