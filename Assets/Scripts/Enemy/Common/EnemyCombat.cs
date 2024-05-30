using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour, IDamageable
{
    [SerializeField] float defaultDamage = 10f;

    [Tooltip("List of Attacks, incase the enemy has multiple attacks")]
    [SerializeField] List<float> attackDamages;
    [SerializeField] Bar healthBar;

    Health health;
    EnemyAI enemyAI;
    EnemyAnimationHandler animationHandler;

    int currentAttackIndex = -1;
    bool isAttacking = false;
    [SerializeField] bool canAttack = false;

    void Awake()
    {
        health = GetComponent<Health>();
        enemyAI = GetComponent<EnemyAI>();
        animationHandler = GetComponentInChildren<EnemyAnimationHandler>();
    }

    void OnEnable()
    {
        GameManager.OnGameOver += HandleStopEnemy;
    }

    void OnDisable()
    {
        GameManager.OnGameOver -= HandleStopEnemy;
    }

    void Update()
    {
        HandleAttack();
    }

    void HandleAttack()
    {
        if (canAttack && !isAttacking)
        {
            SetNewAttackType();
        }
        else if (!canAttack && isAttacking)
        {
            isAttacking = false;
            animationHandler.StopAttacking();
        }
    }

    public void SetNewAttackType()
    {
        isAttacking = true;
        if (attackDamages != null && attackDamages.Count > 0)
        {
            currentAttackIndex = Random.Range(0, attackDamages.Count);
        }
        animationHandler.PlayAttackAnimation(currentAttackIndex);
    }

    public void Attack()
    {
        if (currentAttackIndex != -1)
        {
            Character.Instance?.gameObject.GetComponent<IDamageable>().TakeDamage(attackDamages[currentAttackIndex]);
        }
        else
        {
            Character.Instance?.gameObject.GetComponent<IDamageable>().TakeDamage(defaultDamage);
        }
    }

    public void HandleStopEnemy()
    {
        enemyAI.StopEnemyAI();
        canAttack = false;
    }

    public void TakeDamage(float damage)
    {
        if (health.IsDead) { return; }

        animationHandler.PlayTakeDamageAnimation();
        enemyAI.TriggerEnemy();
        health.TakeDamage(damage);
        // incase enemy has health bar
        if (healthBar != null && healthBar.gameObject.activeInHierarchy)
        {
            healthBar.UpdateSliderValue(health.CurrentHealth);
        }
    }

    public void SetCanAttack(bool canAttack)
    {
        this.canAttack = canAttack;
    }
}
