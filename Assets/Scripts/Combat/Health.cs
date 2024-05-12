using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action<Health> OnDeath;
    public static Action OnHealthAdded;

    public float StartingHealth => startingHealth;
    public float CurrentHealth => currentHealth;
    public bool IsDead => currentHealth <= 0;

    [SerializeField] float startingHealth = 10f;

    float currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void AddHealth(float amount)
    {
        OnHealthAdded?.Invoke();
        if ((currentHealth + amount) >= startingHealth)
        {
            ResetHealth();
            return;
        }
        currentHealth += amount;
    }

    void ResetHealth()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("I'm Dead");
            // OnDeath?.Invoke(this);
        }
    }
}
