using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellRegistry", menuName = "Scriptable Objects/SpellRegistry")]
public class SpellRegistry : ScriptableObject
{
    [SerializeField] List<SpellEntry> spellEntries;

    Dictionary<Spell, GameObject> prefabLookup;

    private void OnEnable()
    {
        prefabLookup = new Dictionary<Spell, GameObject>();
        foreach (var spellEntry in spellEntries)
        {
            if (!prefabLookup.ContainsKey(spellEntry.spell))
                prefabLookup[spellEntry.spell] = spellEntry.prefab;
        }
    }

    public GameObject GetPrefab(Spell spell)
    {
        if (prefabLookup.TryGetValue(spell, out var prefab))
            return prefab;

        Debug.LogError($"No prefab registered for spell: {spell}");
        return null;
    }
}

[System.Serializable]
public struct SpellEntry
{
    public Spell spell;
    public GameObject prefab;
}

public enum Spell
{
    Fireball,
    IceField,
    Push,
    Grow
}