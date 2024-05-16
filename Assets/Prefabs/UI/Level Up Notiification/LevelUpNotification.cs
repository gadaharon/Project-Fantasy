using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpNotification : MonoBehaviour
{
    [SerializeField] FadeTransition levelUpAnimatedText;
    [SerializeField] FadeTransition levelUpInstructionsAnimatedText;

    void OnEnable()
    {
        Character.OnLevelUp += HandleLevelUp;
    }

    void OnDisable()
    {
        Character.OnLevelUp -= HandleLevelUp;
    }

    void HandleLevelUp()
    {
        levelUpAnimatedText.StartTextFadeTransitionInOut();
        levelUpInstructionsAnimatedText.StartTextFadeTransitionInOut();
    }
}
