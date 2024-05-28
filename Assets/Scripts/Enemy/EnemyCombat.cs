using UnityEngine;

public class EnemyCombat : MonoBehaviour, IDamageable
{
    [SerializeField] float damageAmount = 2f;

    Health health;
    EnemyAI enemyAI;
    EnemyAnimationHandler animationHandler;

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
            isAttacking = true;
            animationHandler.PlayAttackAnimation(true);
        }
        else if (!canAttack && isAttacking)
        {
            isAttacking = false;
            animationHandler.PlayAttackAnimation(false);
        }
    }

    public void Attack()
    {
        Character.Instance?.gameObject.GetComponent<IDamageable>().TakeDamage(damageAmount);
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
    }

    public void SetCanAttack(bool canAttack)
    {
        this.canAttack = canAttack;
    }
}
