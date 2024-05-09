using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static PlayerCombat Instance { get; private set; }
    public bool IsAttacking => isAttacking;

    [SerializeField] float comboTimeout = 1f;
    [SerializeField] float AttackCD = .2f; // Attack cooldown

    PlayerAnimationHandler playerAnimationHandler;
    Coroutine comboCoroutine;
    bool isAttacking;
    int maxComboHits = 3;
    int comboHits = 0;
    float lastAttackTime = 0;

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
        if (Input.GetMouseButtonDown(0) && Time.time - lastAttackTime > AttackCD)
        {
            if (comboCoroutine != null && comboHits < maxComboHits)
            {
                StopCoroutine(comboCoroutine);
            }
            comboCoroutine = StartCoroutine(MeleeAttackRoutine());
            lastAttackTime = Time.time;
        }
    }

    void HandleRangeAttack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            playerAnimationHandler.PlaySpellCastAnimation();
        }
        // if (Input.GetMouseButton(1))
        // {
        //     playerAnimationHandler.PlaySpellCastAnimation(true);
        // }
        // else
        // {
        //     playerAnimationHandler.PlaySpellCastAnimation(false);
        // }
    }

    IEnumerator MeleeAttackRoutine()
    {
        if (!isAttacking) { isAttacking = true; }

        comboHits = Mathf.Min(comboHits + 1, maxComboHits);
        playerAnimationHandler.PlayMeleeAttackAnimation(comboHits);

        yield return new WaitForSeconds(comboTimeout);

        comboHits = 0;
        playerAnimationHandler.PlayMeleeAttackAnimation(comboHits);
        isAttacking = false;
    }

    public void SetIsAttacking(bool isAttacking)
    {
        this.isAttacking = isAttacking;
    }

}
