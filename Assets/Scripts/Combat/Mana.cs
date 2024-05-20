using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float CurrentMana => currentMana;

    [SerializeField] float startingMana = 10f;
    [SerializeField] float currentMana;

    void Awake()
    {
        currentMana = startingMana;
    }

    public void UseMana(float amount)
    {
        currentMana -= amount;
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
    }
}
