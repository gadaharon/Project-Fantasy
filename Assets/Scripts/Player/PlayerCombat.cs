using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, IDamageable
{
    public bool IsAttacking => isAttacking;

    [SerializeField] float comboTimeout = 1f;
    [SerializeField] float AttackCD = .2f; // Attack cooldown


    PlayerAnimationHandler playerAnimationHandler;
    Weapon playerWeapon;
    Health health;
    Coroutine comboCoroutine;

    bool isAttacking;
    int maxComboHits = 3;
    int comboHits = 0;
    float lastAttackTime = 0;

    void Awake()
    {
        health = GetComponent<Health>();
        playerAnimationHandler = GetComponentInChildren<PlayerAnimationHandler>();
        playerWeapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        if (GameManager.Instance.State == GameManager.GameState.Playing)
        {
            HandleMeleeAttack();
            HandleRangeAttack();
        }
    }

    void HandleMeleeAttack()
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
    }

    IEnumerator MeleeAttackRoutine()
    {
        if (!isAttacking) { SetIsAttacking(true); }

        comboHits = Mathf.Min(comboHits + 1, maxComboHits);
        playerAnimationHandler.PlayMeleeAttackAnimation(comboHits);

        yield return new WaitForSeconds(comboTimeout);

        comboHits = 0;
        playerAnimationHandler.PlayMeleeAttackAnimation(comboHits);
        SetIsAttacking(false);
    }

    void SetIsAttacking(bool isAttacking)
    {
        playerWeapon.SetCanDamage(isAttacking);
    }

    public void TakeDamage(float damage)
    {
        health.TakeDamage(damage);
    }
}
