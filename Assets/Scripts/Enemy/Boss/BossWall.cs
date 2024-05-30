using System;
using UnityEngine;

[RequireComponent(typeof(InteractionHandler))]
public class BossWall : MonoBehaviour, IInteractable
{
    public static Action OnBossArenaEnter;
    // [SerializeField] EnemyAnimationHandler enemyAnimationHandler;

    public void BeginInteract()
    {
        // if (enemyAnimationHandler != null)
        // {
        //     // enemyAnimationHandler.PlayEnemyRiseAnimation();
        // }
        OnBossArenaEnter?.Invoke();
    }

    public void EndInteract()
    {
        gameObject.SetActive(false);
    }
}
