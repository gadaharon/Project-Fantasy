using System;

public enum LootItemType
{
    HealthPotion,
    ManaPotion
}

[Serializable]
public class LootItem
{
    public LootItemType lootItemType;
    public int amount;
}
