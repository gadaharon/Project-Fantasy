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

    // Serialized for debugging
    // TODO: Remove SerializedField
    [SerializeField] float currentHealth;

    void Awake()
    {
        ResetHealth();
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

    public void ResetHealth()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke(this);
        }
    }
}
