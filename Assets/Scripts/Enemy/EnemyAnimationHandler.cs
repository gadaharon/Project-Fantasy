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

    public void PlayAttackAnimation(bool isAttacking)
    {
        if (animator == null) { return; }

        animator.SetBool("IsAttacking", isAttacking);
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
}
