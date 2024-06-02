using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    [SerializeField] int expAmount = 50;
    Health health;
    EnemyAnimationHandler animationHandler;
    EnemyAI enemyAI;
    Collider body;

    void Awake()
    {
        health = GetComponent<Health>();
        enemyAI = gameObject.GetComponent<EnemyAI>();
        animationHandler = GetComponentInChildren<EnemyAnimationHandler>();
        body = GetComponent<Collider>();
    }

    void OnEnable()
    {
        health.OnDeath += HandleDeath;
    }

    void OnDisable()
    {
        health.OnDeath -= HandleDeath;
    }

    void HandleDeath(Health health)
    {
        enemyAI.StopEnemyAI();
        animationHandler.PlayDeathAnimation();
        ExperienceManager.Instance?.AddExperience(expAmount);

        if (body != null)
        {
            body.enabled = false;
        }
    }
}
