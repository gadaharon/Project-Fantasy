using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, IDamageable
{
    public bool IsAttacking => isAttacking;

    [SerializeField] float comboTimeout = 1f;
    [SerializeField] float AttackCD = .2f; // Attack cooldown
    [SerializeField] Bar healthBar;

    PlayerAnimationHandler playerAnimationHandler;
    Weapon playerWeapon;
    Health health;
    Coroutine comboCoroutine;

    bool isAttacking;
    int maxComboHits = 3;
    int comboHits = 0;
    float lastAttackTime = 0;
    bool isWeaponReady = false;

    void Awake()
    {
        health = GetComponent<Health>();
        playerAnimationHandler = GetComponentInChildren<PlayerAnimationHandler>();
        playerWeapon = GetComponentInChildren<Weapon>();
    }

    void Start()
    {
        healthBar.SetMaxValue(health.StartingHealth);
    }

    void Update()
    {
        if (GameManager.Instance.State == GameState.Playing)
        {
            ReadyWeaponToggle();

            if (isWeaponReady)
            {
                HandleMeleeAttack();
                HandleRangeAttack();
            }
        }
    }

    void ReadyWeaponToggle()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isWeaponReady = !isWeaponReady;
            playerAnimationHandler.ToggleReadyWeaponAnimation(isWeaponReady);
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
        healthBar.UpdateSLiderValue(health.CurrentHealth);
    }
}
