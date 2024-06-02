using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    public Potion HealthPotions => healthPotions;
    public Potion ManaPotions => manaPotions;

    [SerializeField] Potion healthPotions;
    [SerializeField] Potion manaPotions;

    // void Start()
    // {
    //     UpdatePotionsUI(PotionType.Health, healthPotions.AmountOfPotions);
    //     UpdatePotionsUI(PotionType.Mana, manaPotions.AmountOfPotions);
    // }

    void OnEnable()
    {
        Loot.OnLootItems += HandleCollectItems;
    }

    void OnDisable()
    {
        Loot.OnLootItems -= HandleCollectItems;
    }

    void Update()
    {
        if (healthPotions != null)
        {
            UpdatePotionsUI(PotionType.Health, healthPotions.AmountOfPotions);
        }
        if (manaPotions != null)
        {
            UpdatePotionsUI(PotionType.Mana, manaPotions.AmountOfPotions);
        }
    }

    void HandleCollectItems(List<LootItem> items)
    {
        foreach (LootItem item in items)
        {
            switch (item.lootItemType)
            {
                case LootItemType.HealthPotion:
                    AddPotion(PotionType.Health, item.amount);
                    break;
                case LootItemType.ManaPotion:
                    AddPotion(PotionType.Mana, item.amount);
                    break;
                default: return;
            }
        }
    }

    public void AddPotion(PotionType type, int amount)
    {
        if (type == PotionType.Health)
        {
            healthPotions.AddNewPotion(amount);
        }
        else if (type == PotionType.Mana)
        {
            manaPotions.AddNewPotion(amount);
        }
    }

    public void RemovePotion(PotionType type, int amount)
    {
        if (type == PotionType.Health)
        {
            healthPotions.RemovePotion(amount);
        }
        else if (type == PotionType.Mana)
        {
            manaPotions.RemovePotion(amount);
        }
    }

    void UpdatePotionsUI(PotionType potionType, int amount)
    {
        UIManager.Instance.UpdatePotionAmount(potionType, amount);
    }

    public bool CanUsePotion(PotionType potionType)
    {
        if (potionType == PotionType.Health)
        {
            return healthPotions.CanUsePotion();
        }
        else if (potionType == PotionType.Mana)
        {
            return manaPotions.CanUsePotion();
        }
        return false;
    }
}
