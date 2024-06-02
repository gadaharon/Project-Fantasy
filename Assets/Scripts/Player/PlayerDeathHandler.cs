using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    Health health;

    void Awake()
    {
        health = GetComponent<Health>();
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
        Debug.Log("Player is dead");
        // Play death animation
        MenuManager.Instance.ToggleGameOverMenu();
        GameManager.Instance?.SetGameState(GameState.GameOver);
        GameManager.TriggerGameOver();
    }
}
