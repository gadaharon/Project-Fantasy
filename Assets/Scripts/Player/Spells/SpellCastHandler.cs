using System.Collections.Generic;
using UnityEngine;

public class SpellCastHandler : Singleton<SpellCastHandler>
{
    public ElementalType CurrentElementalType => currentElementalType;
    public List<ElementalType> KnownELementalTypes => knownElementalTypes;

    [SerializeField] SpellListSO spellList;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Camera fpsCam;

    Mana playerMana;
    SpellBook spellBook;
    SpellSO currentSpell;

    ElementalType currentElementalType;
    List<ElementalType> knownElementalTypes = new List<ElementalType>();
    int currentElementalTypeIndex = 0;



    // TODO: add projectile object pool

    protected override void Awake()
    {
        base.Awake();

        playerMana = GetComponentInParent<Mana>();
        spellBook = new SpellBook();

        // LearnFireElementalMagic();
    }

    public void LearnSpell(SpellSO newSpell)
    {
        spellBook.AddSpell(newSpell);
    }

    public void SetCurrentSpell(SpellType spellType)
    {
        List<SpellSO> spells = spellBook.GetSpellsByElement(currentElementalType);

        foreach (SpellSO spell in spells)
        {
            if (spell.spellType == spellType)
            {
                currentSpell = spell;
            }
            return;
        }

        Debug.Log("Spell not found: " + spellType);
    }

    void HandleLearnElementalMagic(ElementalType newElementalType, SpellType initialSpellType)
    {
        if (spellBook == null) { return; }

        SpellSO spellSO = spellList.GetSpell(initialSpellType);
        if (spellSO == null) { return; }

        spellBook.LearnNewElementalMagic(newElementalType, spellSO);
        knownElementalTypes.Add(newElementalType);
        currentElementalTypeIndex = knownElementalTypes.Count - 1;
        SetCurrentElementalType(newElementalType);
    }

    public void SetCurrentElementalType(ElementalType elementalType)
    {
        if (spellBook.spellsByElement.ContainsKey(elementalType) && spellBook.spellsByElement[elementalType].Count > 0)
        {
            currentElementalType = elementalType;
            currentSpell = spellBook.spellsByElement[elementalType][0];
            SetCurrentElementalTypeUI();
            Debug.Log("Switched to " + elementalType + " magic");
        }
        else
        {
            Debug.Log("No spells available for " + elementalType + " magic");
        }
    }

    void SetCurrentElementalTypeUI()
    {
        if (currentSpell == null)
        {
            UIManager.Instance?.ToggleCurrentElementUI(false);
            return;
        }

        UIManager.Instance?.ToggleCurrentElementUI(true);
        UIManager.Instance?.UpdateCurrentElementUISprite(currentSpell.elementSprite);
    }

    public void CastCurrentSpell()
    {
        if (currentSpell == null)
        {
            Debug.Log("No spell selected to cast.");
            return;
        }

        if (CanCastSpell())
        {
            playerMana.UseMana(currentSpell.manaCost);
            Instantiate(currentSpell.spellPrefab, spawnPoint.position, fpsCam.transform.rotation);
        }
        else
        {
            Debug.Log("Not enough mana to cast " + currentSpell.spellName);
        }
    }

    public bool CanCastSpell()
    {
        if (currentSpell == null) { return false; }

        return playerMana.CurrentMana >= currentSpell.manaCost;
    }

    void LearnFireElementalMagic()
    {
        HandleLearnElementalMagic(ElementalType.Fire, SpellType.FireBall);
    }
    void LearnWaterElementalMagic()
    {
        HandleLearnElementalMagic(ElementalType.Water, SpellType.IceProjectile);
    }

    public void LearnElementalMagicByType(ElementalType elementalType)
    {
        if (elementalType == ElementalType.Fire)
        {
            LearnFireElementalMagic();
            return;
        }

        if (elementalType == ElementalType.Water)
        {
            LearnWaterElementalMagic();
            return;
        }
    }

    public void SwitchToNextElementType()
    {
        if (currentElementalTypeIndex < KnownELementalTypes.Count - 1)
        {
            currentElementalTypeIndex++;
        }
        else
        {
            currentElementalTypeIndex = 0;
        }
        SetCurrentElementalType(KnownELementalTypes[currentElementalTypeIndex]);
    }

    public void SwitchToPreviousElementType()
    {
        if (currentElementalTypeIndex > 0)
        {
            currentElementalTypeIndex--;
        }
        else
        {
            currentElementalTypeIndex = KnownELementalTypes.Count - 1;
        }
        SetCurrentElementalType(KnownELementalTypes[currentElementalTypeIndex]);
    }
}
