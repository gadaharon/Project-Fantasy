using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    Animator animator;
    SpellCastHandler spellCastHandler;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spellCastHandler = GetComponent<SpellCastHandler>();
    }

    public void PlayMeleeAttackAnimation(int comboHit)
    {
        animator.SetInteger("ComboHit", comboHit);
    }

    public void ToggleReadyWeaponAnimation(bool readyWeapon)
    {
        animator.SetBool("ReadyWeapon", readyWeapon);
    }

    // This one currently not in use
    // Will be usefull if we'll add actions that require player to hold the key
    // e.g. firestream
    // public void PlaySpellCastAnimation(bool isSpellCasting)
    // {
    //     animator.SetBool("IsSpellcasting", isSpellCasting);
    // }
    public void PlaySpellCastAnimation()
    {
        if (spellCastHandler.CanCastSpell())
        {
            animator.SetTrigger("RangeAttack");
        }
    }

    void SpellCastAnimationEvent()
    {
        spellCastHandler.CastCurrentSpell();
    }

    void MeleeAttackAnimationEvent()
    {
        AudioManager.Instance.PlaySwordSwingSFX();
    }
}
