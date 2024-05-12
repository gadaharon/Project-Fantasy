using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    Animator animator;
    ProjectileShooter projectileShooter;

    void Awake()
    {
        animator = GetComponent<Animator>();
        projectileShooter = GetComponent<ProjectileShooter>();
    }

    public void PlayMeleeAttackAnimation(int comboHit)
    {
        animator.SetInteger("ComboHit", comboHit);
    }

    // This one currently not in use
    // Will be usefull if we'll add actions that require player to hold the key
    // e.g. firestream
    public void PlaySpellCastAnimation(bool isSpellCasting)
    {
        animator.SetBool("IsSpellcasting", isSpellCasting);
    }
    public void PlaySpellCastAnimation()
    {
        animator.SetTrigger("RangeAttack");
    }

    void SpellCastAnimationEvent()
    {
        projectileShooter.ShootProjectile();
    }
}
