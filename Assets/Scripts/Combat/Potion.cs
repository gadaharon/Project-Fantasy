using System;
using UnityEngine;

public enum PotionType
{
    Health,
    Mana
}

[Serializable]
public class Potion
{
    public int AmountOfPotions => amountOfPotions;
    public PotionType Type => potionType;
    public float RegainAmount => regainAmount;

    [SerializeField] int amountOfPotions;
    [SerializeField] PotionType potionType;
    [SerializeField] float regainAmount;

    public Potion(int amountOfPotions, PotionType potionType, float regainAmount)
    {
        this.amountOfPotions = amountOfPotions;
        this.potionType = potionType;
        this.regainAmount = regainAmount;
    }

    public void AddNewPotion(int amount)
    {
        amountOfPotions += amount;
    }

    public bool RemovePotion(int amount)
    {
        if (amountOfPotions >= amount)
        {
            amountOfPotions -= amount;
            return true;
        }
        return false;
    }

    public bool CanUsePotion()
    {
        return amountOfPotions > 0;
    }
}
