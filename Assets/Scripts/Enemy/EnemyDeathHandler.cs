using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    Health health;
    EnemyAnimationHandler animationHandler;
    EnemyAI enemyAI;

    int expAmount = 100;

    void Awake()
    {
        health = GetComponent<Health>();
        enemyAI = gameObject.GetComponent<EnemyAI>();
        animationHandler = GetComponent<EnemyAnimationHandler>();
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
        ExperienceManager.Instance.AddExperience(expAmount);
    }
}
