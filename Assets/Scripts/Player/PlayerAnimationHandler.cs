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
