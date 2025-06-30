using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Different spell words that the spell count has
public enum SpellWord { Fire, Push, Size, Reverse}

public class SpellQueue
{
    // Tracks the count of each spell word
    Dictionary<SpellWord, int> spellCounts = new Dictionary<SpellWord, int>()
    {
        { SpellWord.Fire, 0 },
        { SpellWord.Push, 0 },
        { SpellWord.Size, 0 },
        { SpellWord.Reverse, 0 }
    };

    // Max total combined count allowed in the queue
    private int _maxTotalCount = 4;
    public int MaxTotalCount 
    { 
        get => _maxTotalCount;
        // Clamps queue to be from 1-4 to prevent errors
        set => _maxTotalCount = Mathf.Clamp(value, 1, 4);
    }

    // Gets the total count of the spell counts by summing the values of spellCounts
    int TotalCount => spellCounts.Values.Sum();

    // Increases the spell count of the key by one
    public void AddSpell(SpellWord spellWord)
    {
        //Debug.Log($"Adding spell to queue: {spellWord}");

        if (TotalCount < MaxTotalCount)
        {
            spellCounts[spellWord] += 1;
            //Debug.Log($"Spell ({spellWord}) updated count to: {spellCounts[spellWord]}");
        }
    }

    // Clears the spell counts by setting them all to 0
    public void ClearQueue()
    {
        // Loops through each key in spell counts
        foreach(SpellWord spellWord in spellCounts.Keys.ToList())
        {
            // Set count of the key to 0
            spellCounts[spellWord] = 0;
        }

        //Debug.Log("Spell queue cleared");
    }

    // Gets count of a given spell word
    public int GetCountOf(SpellWord spellWord) => spellCounts[spellWord];

    // Checks if the queue has a certain spell word
    public bool Contains(SpellWord spellWord) => spellCounts[spellWord] > 0;
}