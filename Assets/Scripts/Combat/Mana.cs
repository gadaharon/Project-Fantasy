using UnityEngine;

public class Mana : MonoBehaviour
{
    public float StartingMana => startingMana;
    public float CurrentMana => currentMana;

    [SerializeField] float startingMana = 10f;
    [SerializeField] float currentMana;

    void Awake()
    {
        ResetMana();
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

    public void ResetMana()
    {
        currentMana = startingMana;
    }
}
