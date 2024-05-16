using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Attribute : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] TextMeshProUGUI skillLevel;
    [SerializeField] Button addButton;
    [SerializeField] Button subtractButton;

    Skill skill;
    Character character;
    SkillMenu skillMenu;

    int initialSkillLevel;
    int initialSkillPoints;
    bool canUpgradeSkills;

    void Awake()
    {
        skillMenu = GetComponentInParent<SkillMenu>();
    }

    void OnEnable()
    {
        Setup();
        skillMenu.OnRevertChanges += HandleRevertChanges;
    }

    void OnDisable()
    {
        skillMenu.OnRevertChanges -= HandleRevertChanges;
    }

    void Update()
    {
        if (canUpgradeSkills)
        {
            UpdateButtonsState();
        }
    }


    void Setup()
    {
        character = Character.Instance;
        if (character == null) { return; }

        skill = character.CharacterSkills.GetSkill(name);
        initialSkillPoints = character.SkillPoints;

        if (skill != null)
        {
            initialSkillLevel = skill.level;
            UpdateSkillLevelText();
        }

        HandleButtonsVisibility();
    }

    void HandleRevertChanges()
    {
        skill.SetSkillLevel(initialSkillLevel);
    }

    void HandleButtonsVisibility()
    {
        canUpgradeSkills = initialSkillPoints > 0;
        addButton.gameObject.SetActive(canUpgradeSkills);
        subtractButton.gameObject.SetActive(canUpgradeSkills);
    }

    void UpdateButtonsState()
    {
        subtractButton.interactable = skill.level != initialSkillLevel && initialSkillPoints > 0;
        addButton.interactable = character.SkillPoints > 0;
    }

    void UpdateSkillLevelText()
    {
        skillLevel.text = skill.level.ToString();
    }

    public void IncreaseSkillLevel()
    {
        if (character.SkillPoints > 0)
        {
            character.RemoveSkillPoint();
            skill.IncreaseLevel();
            UpdateSkillLevelText();
            skillMenu?.UpdateSaveButtonState();
        }
    }

    public void DecreaseSkillLevel()
    {
        if (skill.level != initialSkillLevel && initialSkillLevel > 0)
        {
            character.AddSkillPoint();
            skill.DecreaseLevel();
            UpdateSkillLevelText();
            skillMenu?.UpdateSaveButtonState();
        }
    }
}
