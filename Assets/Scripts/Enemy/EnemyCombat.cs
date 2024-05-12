using UnityEngine;

public class EnemyCombat : MonoBehaviour, IDamageable
{
    Health health;
    EnemyAI enemyAI;
    EnemyAttackTrigger attackTrigger;

    void Awake()
    {
        health = GetComponent<Health>();
        enemyAI = GetComponent<EnemyAI>();
        attackTrigger = GetComponentInChildren<EnemyAttackTrigger>();
    }

    void Update()
    {
        if (attackTrigger.CanAttack)
        {
            // Debug.Log("Attacking Player");
        }
    }

    public void TakeDamage(float damage)
    {
        enemyAI.StartFollow();
        health.TakeDamage(damage);
    }
}
