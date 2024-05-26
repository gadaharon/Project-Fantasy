using System;
using System.Collections.Generic;
using UnityEngine;

public class Loot : InteractableInput
{
    public static Action<List<LootItem>> OnLootItems;
    [SerializeField] List<LootItem> lootItems = new List<LootItem>();

    protected override void HandleInteraction()
    {
        OnLootItems?.Invoke(lootItems);
    }
}
