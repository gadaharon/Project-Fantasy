using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour
{
    public Action OnRevertChanges;

    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI skillPoints;
    [SerializeField] Button saveChangesButton;
    [SerializeField] string levelUpTitle;
    [SerializeField] string levelStatusTitle;

    Character character;
    int initialSkillPoints;

    void OnEnable()
    {
        Setup();
    }

    void Update()
    {
        if (character == null) { return; }

        if (skillPoints.gameObject.activeSelf)
        {
            skillPoints.text = $"Skill Points: {character.SkillPoints}";
        }
    }

    void Setup()
    {
        character = Character.Instance;
        if (character == null) { return; }

        initialSkillPoints = character.SkillPoints;
        UISetup();
    }

    void UISetup()
    {
        bool canUpgradeSkills = initialSkillPoints > 0;
        saveChangesButton.gameObject.SetActive(canUpgradeSkills);
        skillPoints.gameObject.SetActive(canUpgradeSkills);

        string menuTitle = $"{levelStatusTitle} {character.CurrentLevel}";
        if (canUpgradeSkills) { menuTitle = levelUpTitle; }
        title.text = menuTitle;
    }

    public void UpdateSaveButtonState()
    {
        saveChangesButton.interactable = initialSkillPoints != character.SkillPoints && initialSkillPoints > 0;
    }

    public void HandleSaveSkillChanges()
    {
        // TODO: Save skills changes to PlayerRef or json file
        MenuManager.Instance?.ToggleMenu(gameObject);
    }

    public void HandleCloseMenu()
    {
        OnRevertChanges?.Invoke();
        RevertChanges();
        MenuManager.Instance?.ToggleMenu(gameObject);
    }

    void RevertChanges()
    {
        character.SetSkillPoints(initialSkillPoints);
    }
}
