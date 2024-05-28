using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject invisibleWall;
    [SerializeField] FadeTransition potionsLootTextPrompt;

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
    }

    void HandleDisplayLootTutorialPrompt(List<LootItem> items)
    {
        potionsLootTextPrompt.StartTextFadeTransitionInOut();
    }
}
