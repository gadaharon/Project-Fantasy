using System;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Character : Singleton<Character>
{
    public int SkillPoints => skillPoints;
    public int CurrentLevel => currentLevel;
    public int MaxExp => maxExperience;
    public int CurrentExp => currentExperience;
    public CharacterSkills CharacterSkills => characterSkills;

    public static Action OnLevelUp;

    [SerializeField] int maxExperience = 250;
    [SerializeField] int currentExperience = 0;
    [SerializeField] int skillPoints = 0;
    [SerializeField] int currentLevel = 1;

    [Header("Skills")]
    [SerializeField] List<Skill> skills = new List<Skill>();


    StarterAssetsInputs starterAssetsInputs;
    CharacterSkills characterSkills;

    protected override void Awake()
    {
        base.Awake();

        starterAssetsInputs = GetComponentInChildren<StarterAssetsInputs>();
        characterSkills = new CharacterSkills(skills);
    }

    void Start()
    {
        ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
    }

    void OnDisable()
    {
        ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    }

    void HandleExperienceChange(int newExp)
    {
        currentExperience += newExp;
        if (currentExperience <= maxExperience)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        Debug.Log("LEVEL UP!!!");
        // Increase max health
        // set to full health
        currentLevel++;
        AddSkillPoint();
        currentExperience = 0;
        maxExperience += 100;
        OnLevelUp?.Invoke();
    }

    public void SetSkillPoints(int newSkillPoints)
    {
        skillPoints = newSkillPoints;
    }

    public void AddSkillPoint()
    {
        skillPoints++;
    }

    public void RemoveSkillPoint()
    {
        skillPoints--;
    }

    public void SetCharacterCursorLook(bool newState)
    {
        starterAssetsInputs.cursorLocked = newState;
        starterAssetsInputs.cursorInputForLook = newState;
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
