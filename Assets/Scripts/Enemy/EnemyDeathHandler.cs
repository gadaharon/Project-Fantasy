using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    Health health;
    EnemyAnimationHandler animationHandler;
    EnemyAI enemyAI;
    Collider body;

    int expAmount = 100;

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
        Debug.Log("I'm dead");
        enemyAI.StopEnemyAI();
        animationHandler.PlayDeathAnimation();
        ExperienceManager.Instance?.AddExperience(expAmount);

        if (body != null)
        {
            body.enabled = false;
        }
    }
}
