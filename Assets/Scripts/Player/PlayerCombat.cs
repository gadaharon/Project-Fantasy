using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static PlayerCombat Instance { get; private set; }
    public bool IsAttacking => isAttacking;

    [SerializeField] float comboTimeout = 1f;

    PlayerAnimationHandler playerAnimationHandler;
    Coroutine comboCoroutine;
    bool isAttacking;
    int comboHits = 0;

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
        HandleMeleeAttack();
        HandleRangeAttack();
    }

    private void HandleMeleeAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (comboCoroutine != null)
            {
                StopCoroutine(comboCoroutine);
            }
            comboCoroutine = StartCoroutine(MeleeAttackRoutine());
        }
    }

    void HandleRangeAttack()
    {
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

    IEnumerator MeleeAttackRoutine()
    {
        if (!isAttacking) { isAttacking = true; }

        comboHits = Mathf.Min(comboHits + 1, 3);
        playerAnimationHandler.PlayMeleeAttackAnimation(comboHits);

        yield return new WaitForSeconds(comboTimeout);

        comboHits = 0;
        playerAnimationHandler.PlayMeleeAttackAnimation(comboHits);
        isAttacking = false;
    }

}
