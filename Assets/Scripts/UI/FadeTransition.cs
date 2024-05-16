using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeTransition : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textFade;
    [SerializeField] float fadeTransitionTime = 4f;

    readonly int TEXT_FADE_IN = Animator.StringToHash("TextFadeIn");
    readonly int TEXT_FADE_OUT = Animator.StringToHash("TextFadeOut");

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartTextFadeTransitionInOut()
    {
        StartCoroutine(FadeInOutRoutine());
    }

    IEnumerator FadeInOutRoutine()
    {
        animator.Play(TEXT_FADE_IN);

        yield return new WaitForSeconds(fadeTransitionTime);

        animator.Play(TEXT_FADE_OUT);
    }
}
