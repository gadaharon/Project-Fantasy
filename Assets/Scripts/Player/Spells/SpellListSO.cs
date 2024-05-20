using System;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType
{
    FireBall,
    IceProjectile
}

[CreateAssetMenu(fileName = "NewSpellList", menuName = "Spells/Spell List")]
public class SpellListSO : ScriptableObject
{
    public List<SpellSO> spellList;

    public SpellSO GetSpell(SpellType spellType)
    {
        foreach (SpellSO spell in spellList)
        {
            if (spell.spellType == spellType)
            {
                return spell;
            }
        }
        Debug.LogWarning($"Spell {spellType} not found in the spell list");
        return null;
    }
}
