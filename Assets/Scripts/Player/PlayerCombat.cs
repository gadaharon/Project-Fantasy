using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static PlayerCombat Instance { get; private set; }
    public bool IsAttacking => isAttacking;

    PlayerAnimationHandler playerAnimationHandler;
    bool isAttacking;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        playerAnimationHandler = GetComponentInChildren<PlayerAnimationHandler>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (playerAnimationHandler != null)
            {
                playerAnimationHandler.PlayMeleeAttackAnimation();
            }
        }

        if (Input.GetMouseButton(1))
        {
            playerAnimationHandler.PlaySpellCastAnimation(true);
        }
        else
        {
            playerAnimationHandler.PlaySpellCastAnimation(false);
        }
    }

    public void SetIsAttacking(bool isAttacking)
    {
        this.isAttacking = isAttacking;
    }

}
