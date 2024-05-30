using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    Animator animator;
    EnemyCombat enemyCombat;

    void Awake()
    {
        animator = GetComponent<Animator>();
        enemyCombat = GetComponentInParent<EnemyCombat>();
    }

    public void PlayEnemyRiseAnimation()
    {
        if (animator == null) { return; }

        animator.SetTrigger("Rise");
    }

    public void PlayEnemyMoveAnimation(bool isMoving)
    {
        if (isMoving && !animator.GetBool("Move"))
        {
            animator.SetBool("Move", true);
        }
        else if (!isMoving && animator.GetBool("Move"))
        {
            animator.SetBool("Move", false);
        }
    }

    public void PlayAttackAnimation(int attackType)
    {
        if (animator == null) { return; }

        if (attackType != -1)
        {
            animator.SetInteger("AttackType", attackType);
        }
        animator.SetBool("IsAttacking", true);
    }

    public void StopAttacking()
    {
        if (animator == null) { return; }

        animator.SetBool("IsAttacking", false);
    }

    public void PlayTakeDamageAnimation()
    {
        animator.SetTrigger("TakeDamage");
    }

    public void PlayDeathAnimation()
    {
        if (animator == null) { return; }

        animator.SetTrigger("Death");
    }

    public void AttackAnimationEvent()
    {
        enemyCombat.Attack();
    }

    public void AttackFinishAnimationEvent()
    {
        enemyCombat.SetNewAttackType();
    }
}
