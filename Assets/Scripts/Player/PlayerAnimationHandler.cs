using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    PlayerCombat playerCombat;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        playerCombat = PlayerCombat.Instance;
    }

    public void PlayMeleeAttackAnimation()
    {
        playerCombat.SetIsAttacking(true);
        animator.SetTrigger("Attack");
    }

    public void PlaySpellCastAnimation(bool isSpellCasting)
    {
        animator.SetBool("IsSpellcasting", isSpellCasting);
    }

    void OnAttackFinishedAnimEvent()
    {
        playerCombat.SetIsAttacking(false);
    }
}
