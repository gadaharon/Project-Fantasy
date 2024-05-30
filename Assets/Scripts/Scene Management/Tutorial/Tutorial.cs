using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject invisibleWall;
    [SerializeField] FadeTransition potionsLootTextPrompt;
    [SerializeField] FadeTransition combatTutorialPrompt;

    void OnEnable()
    {
        ElementalMagicRock.OnElementalMagicLearned += HandleOnElementalMagicLearn;
        Loot.OnLootItems += HandleDisplayLootTutorialPrompt;
    }

    void OnDisable()
    {
        ElementalMagicRock.OnElementalMagicLearned -= HandleOnElementalMagicLearn;
        Loot.OnLootItems -= HandleDisplayLootTutorialPrompt;
    }

    void HandleOnElementalMagicLearn()
    {
        invisibleWall.SetActive(false);
        combatTutorialPrompt.StartTextFadeTransitionInOut();
    }

    void HandleDisplayLootTutorialPrompt(List<LootItem> items)
    {
        potionsLootTextPrompt.StartTextFadeTransitionInOut();
    }
}
