using System;
using UnityEngine;

public class SpellCasterBuilder
{
    readonly SpellRegistry _spellRegistry;

    public SpellCasterBuilder(SpellRegistry spellRegistry)
    {
        _spellRegistry = spellRegistry;
    }

    public SpellCaster CreateSpellCaster(SpellQueue spellQueue)
    {
        // If spell has fire but no ice, create a damage projectile
        if (spellQueue.Contains(SpellWord.Fire) && !spellQueue.Contains(SpellWord.Reverse))
        {
            float speedMult = 1f;
            float sizeMult = 1f;

            // If spell queue has Push, set a speed mult based on how many
            if (spellQueue.Contains(SpellWord.Push))
            {
                int pushCount = spellQueue.GetCountOf(SpellWord.Push);
                speedMult += pushCount;
            }

            // If spell queue has Size, set a size mult based on how many
            if (spellQueue.Contains(SpellWord.Size))
            {
                int sizeCount = spellQueue.GetCountOf(SpellWord.Size);
                sizeMult += sizeCount;
            }

            return new ProjectileCaster(_spellRegistry.GetPrefab(Spell.Fireball), speedMult, sizeMult);
        }

        // If spell contains fire and reverse, create a freeze area
        if (spellQueue.Contains(SpellWord.Fire))
        {
            float sizeMult = 1f;

            if (spellQueue.Contains(SpellWord.Size))
            {
                int sizeCount = spellQueue.GetCountOf(SpellWord.Size);
                sizeMult += sizeCount;
            }

            return new AreaCaster(_spellRegistry.GetPrefab(Spell.IceField), sizeMult);
        }

        // If spell contains push and no fire, create a push projectile 
        if (spellQueue.Contains(SpellWord.Push))
        {
            float speedMult = 1f;
            float sizeMult = 1f;

            // If spell queue has Push, set a speed mult based on how many
            if (spellQueue.Contains(SpellWord.Push))
            {
                int pushCount = spellQueue.GetCountOf(SpellWord.Push);
                speedMult += pushCount;
            }

            // If spell queue has Size, set a size mult based on how many
            if (spellQueue.Contains(SpellWord.Size))
            {
                int sizeCount = spellQueue.GetCountOf(SpellWord.Size);
                sizeMult += sizeCount;
            }

            return new ProjectileCaster(_spellRegistry.GetPrefab(Spell.Push), speedMult, sizeMult);
        }

        // If spell has size and no fire or push, cast a size projectile
        if (spellQueue.Contains(SpellWord.Size))
        {
            float speedMult = 1f;
            float sizeMult = 1f;

            // If spell queue has Push, set a speed mult based on how many
            if (spellQueue.Contains(SpellWord.Push))
            {
                int pushCount = spellQueue.GetCountOf(SpellWord.Push);
                speedMult += pushCount;
            }

            // If spell queue has Size, set a size mult based on how many
            if (spellQueue.Contains(SpellWord.Size))
            {
                int sizeCount = spellQueue.GetCountOf(SpellWord.Size);
                sizeMult += sizeCount;
            }

            return new ProjectileCaster(_spellRegistry.GetPrefab(Spell.Grow), speedMult, sizeMult);
        }

        throw new InvalidSpellException("Spell queue did not have a valid spell. No spell will be cast.");
    }
}
