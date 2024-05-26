using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float CurrentMana => currentMana;

    [SerializeField] float startingMana = 10f;
    [SerializeField] float currentMana;
    [SerializeField] Bar manaBar;

    void Awake()
    {
        currentMana = startingMana;
    }

    void Start()
    {
        manaBar.SetMaxValue(startingMana);
    }

    public void UseMana(float amount)
    {
        currentMana -= amount;
        manaBar.UpdateSliderValue(currentMana);
        if (currentMana < 0)
        {
            currentMana = 0;
        }
    }

    public void RegainMana(float amount)
    {
        currentMana += amount;

        if (currentMana > startingMana)
        {
            currentMana = startingMana;
        }
        manaBar.UpdateSliderValue(currentMana);
    }
}
