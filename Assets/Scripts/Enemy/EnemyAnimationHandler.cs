using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAttackAnimation(bool isAttacking)
    {
        if (animator == null) { return; }

        animator.SetBool("IsAttacking", isAttacking);
    }

    public void PlayDeathAnimation()
    {
        if (animator == null) { return; }

        animator.SetTrigger("Death");
    }
}
