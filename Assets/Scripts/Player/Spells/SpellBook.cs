using System.Collections.Generic;
using UnityEngine;

public class SpellBook
{
    public Dictionary<ElementalType, List<SpellSO>> spellsByElement = new Dictionary<ElementalType, List<SpellSO>>();

    public void LearnNewElementalMagic(ElementalType elementalType, SpellSO spell)
    {
        if (spellsByElement.ContainsKey(elementalType))
        {
            Debug.Log("Element already exist");
            return;
        }
        spellsByElement[elementalType] = new List<SpellSO>();
        AddSpell(spell);
    }

    public void AddSpell(SpellSO spell)
    {
        if (!spellsByElement.ContainsKey(spell.elementalType))
        {
            Debug.Log("Elemental type of this spell doesn't exist" + spell.spellName);
            return;
        }
        if (IsSpellExistInElement(spell))
        {
            Debug.Log("Spell " + spell.name + " already exists");
            return;
        }

        spellsByElement[spell.elementalType].Add(spell);
    }

    bool IsSpellExistInElement(SpellSO spell)
    {
        return spellsByElement[spell.elementalType].Contains(spell);
    }

    public List<SpellSO> GetSpellsByElement(ElementalType elementalType)
    {
        return spellsByElement[elementalType];
    }

}
