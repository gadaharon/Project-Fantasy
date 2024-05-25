using UnityEngine;

public enum ElementalType
{
    Fire,
    Water,
    Earth,
    Air
}

[CreateAssetMenu(fileName = "NewSpell", menuName = "Spells/New Spell")]
public class SpellSO : ScriptableObject
{
    public string spellName;
    public SpellType spellType;
    public ElementalType elementalType;
    public float manaCost;
    public GameObject spellPrefab;
    public Sprite elementSprite;
}
