using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] string bossDisplayName;
    [SerializeField] Bar bossHealthBar;

    Health health;
    EnemyAnimationHandler animationHandler;

    void Awake()
    {
        health = GetComponent<Health>();
        animationHandler = GetComponentInChildren<EnemyAnimationHandler>();
    }

    void OnEnable()
    {
        BossWall.OnBossArenaEnter += HandleBossArenaEnter;
        health.OnDeath += HandleOnBossDefeat;
    }

    void OnDisable()
    {
        BossWall.OnBossArenaEnter -= HandleBossArenaEnter;
        health.OnDeath -= HandleOnBossDefeat;
    }

    void HandleBossArenaEnter()
    {
        if (health == null) { return; }

        animationHandler.PlayEnemyRiseAnimation();
        UIManager.Instance.ToggleBossHealthBar(true);
        UIManager.Instance.SetBossDisplayName(bossDisplayName);

        bossHealthBar.SetMaxValue(health.StartingHealth);
    }

    void HandleOnBossDefeat(Health sender)
    {
        UIManager.Instance.ToggleBossHealthBar(false);
    }
}
