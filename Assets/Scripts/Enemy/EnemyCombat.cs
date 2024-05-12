using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour, IDamageable
{
    Health health;

    void Awake()
    {
        health = GetComponent<Health>();
    }

    public void TakeDamage(float damage)
    {
        health.TakeDamage(damage);
    }
}
