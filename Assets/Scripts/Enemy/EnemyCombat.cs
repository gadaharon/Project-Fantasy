using UnityEngine;

public class EnemyCombat : MonoBehaviour, IDamageable
{
    [SerializeField] float damageAmount = 2f;

    Health health;
    EnemyAI enemyAI;
    EnemyAnimationHandler animationHandler;

    bool isAttacking = false;
    bool canAttack = false;

    void Awake()
    {
        health = GetComponent<Health>();
        enemyAI = GetComponent<EnemyAI>();
        animationHandler = GetComponent<EnemyAnimationHandler>();
    }

    void OnEnable()
    {
        GameManager.OnGameOver += HandleGameOver;
    }

    void OnDisable()
    {
        GameManager.OnGameOver -= HandleGameOver;
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
        Character.Instance.gameObject.GetComponent<IDamageable>().TakeDamage(damageAmount);
    }

    public void HandleGameOver()
    {
        enemyAI.StopEnemyAI();
        canAttack = false;
    }

    public void TakeDamage(float damage)
    {
        enemyAI.TriggerEnemy();
        health.TakeDamage(damage);
    }

    public void SetCanAttack(bool canAttack)
    {
        this.canAttack = canAttack;
    }
}
