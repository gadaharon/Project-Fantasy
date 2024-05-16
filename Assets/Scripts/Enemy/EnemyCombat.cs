using UnityEngine;

public class EnemyCombat : MonoBehaviour, IDamageable
{
    Health health;
    EnemyAI enemyAI;
    EnemyAttackTrigger attackTrigger;
    EnemyAnimationHandler animationHandler;

    bool isAttacking = false;

    void Awake()
    {
        health = GetComponent<Health>();
        enemyAI = GetComponent<EnemyAI>();
        animationHandler = GetComponent<EnemyAnimationHandler>();
        attackTrigger = GetComponentInChildren<EnemyAttackTrigger>();
    }

    void Update()
    {
        HandleAttack();
    }

    void HandleAttack()
    {
        if (attackTrigger.CanAttack && !isAttacking)
        {
            isAttacking = true;
            animationHandler.PlayAttackAnimation(true);
        }
        else if (!attackTrigger.CanAttack && isAttacking)
        {
            isAttacking = false;
            animationHandler.PlayAttackAnimation(false);
        }
    }

    public void TakeDamage(float damage)
    {
        enemyAI.TriggerEnemy();
        health.TakeDamage(damage);
    }
}
