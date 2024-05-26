using System;
using TMPro;
using UnityEngine;

public class ElementalMagicRock : InteractableInput
{
    public static Action OnElementalMagicLearned;

    [SerializeField] ElementalType rockElementalType;
    [SerializeField] TextMeshPro displayTextMeshPro;
    [SerializeField] string displayText;
    [SerializeField] Color textColor = Color.white;

    protected override void Awake()
    {
        base.Awake();
        displayTextMeshPro.text = displayText;
        displayTextMeshPro.color = textColor;
    }

    protected override void HandleInteraction()
    {
        SpellCastHandler.Instance?.LearnElementalMagicByType(rockElementalType);
        OnElementalMagicLearned?.Invoke();
    }
}
