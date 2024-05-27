using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, IDamageable
{
    public bool IsAttacking => isAttacking;

    [SerializeField] float comboTimeout = 1f;
    [SerializeField] float AttackCD = .2f; // Attack cooldown
    [SerializeField] Bar healthBar;
    [SerializeField] float meleeDamageMultiplier = 0.5f;
    [SerializeField] float damageReductionMultiplier = 0.4f;



    PlayerAnimationHandler playerAnimationHandler;
    Health health;
    Mana mana;
    Coroutine comboCoroutine;
    Weapon playerWeapon;


    bool isAttacking;
    int maxComboHits = 3;
    int comboHits = 0;
    float lastAttackTime = 0;
    bool isWeaponReady = false;
    float minimumDamageTaken = 1;

    void Awake()
    {
        health = GetComponent<Health>();
        mana = GetComponent<Mana>();
        playerAnimationHandler = GetComponentInChildren<PlayerAnimationHandler>();
        playerWeapon = GetComponentInChildren<Weapon>();
    }

    void OnEnable()
    {
        playerWeapon.OnTargetHit += HandleMeleeWeaponHit;
    }

    void OnDisable()
    {
        playerWeapon.OnTargetHit -= HandleMeleeWeaponHit;
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
            HandleConsumablesInput();

            if (isWeaponReady)
            {
                HandleMeleeAttack();
                HandleRangeAttack();
            }
        }
    }

    void HandleConsumablesInput()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Gain Health
            HandleUseHealthPotion();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            // Gain Mana
            HandleUseManaPotion();
        }
    }


    void HandleUseHealthPotion()
    {
        if (Inventory.Instance.CanUsePotion(PotionType.Health))
        {
            health.AddHealth(Inventory.Instance.HealthPotions.RegainAmount);
            Inventory.Instance.RemovePotion(PotionType.Health, 1);
            healthBar.UpdateSliderValue(health.CurrentHealth);
        }
    }

    void HandleUseManaPotion()
    {
        if (Inventory.Instance.CanUsePotion(PotionType.Mana))
        {
            mana.RegainMana(Inventory.Instance.ManaPotions.RegainAmount);
            Inventory.Instance.RemovePotion(PotionType.Mana, 1);
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

    void HandleMeleeWeaponHit(Collider target, float weaponBaseDamage)
    {
        float damage = CalculateDamage(weaponBaseDamage);
        target.GetComponent<IDamageable>()?.TakeDamage(damage);
    }

    float CalculateDamage(float baseDamage)
    {
        Skill skill = Character.Instance.GetSkillByType(SkillType.Strength);
        float maxDamage = baseDamage + skill.level * meleeDamageMultiplier;
        return Mathf.Round(Random.Range(baseDamage, maxDamage + 1));
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
        Skill skill = Character.Instance.GetSkillByType(SkillType.Defense);
        float damageReduction = skill.level * damageReductionMultiplier;
        float damageTaken = Mathf.RoundToInt(Random.Range(damage - damageReduction, damage));

        health.TakeDamage(Mathf.Max(damageTaken, minimumDamageTaken));
        healthBar.UpdateSliderValue(health.CurrentHealth);
    }
}
