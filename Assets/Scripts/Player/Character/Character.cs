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

    [Header("Level and EXP")]
    [SerializeField] int baseEXP = 100;
    [SerializeField] float expGrowthRate = 1.5f;
    [SerializeField] int skillPoints = 0;
    [SerializeField] int currentLevel = 1;

    [Header("Skills")]
    [SerializeField] List<Skill> skills = new List<Skill>();


    [Header("For Testing")]
    [SerializeField] int maxExperience = 100;
    [SerializeField] int currentExperience = 0;

    StarterAssetsInputs starterAssetsInputs;
    CharacterSkills characterSkills;



    protected override void Awake()
    {
        base.Awake();

        starterAssetsInputs = GetComponentInChildren<StarterAssetsInputs>();
        characterSkills = new CharacterSkills(skills);
        if (currentLevel > 1)
        {
            maxExperience = CalculateMaxExpForNextLevel(currentLevel);
        }
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

    // Returning the remaining exp
    // TODO - add XP for next level in UI
    // public int CalculateXPForNextLevel()
    // {
    //     return Mathf.CeilToInt(baseEXP * MathF.Pow(expGrowthRate, currentLevel));
    // }

    int CalculateEXPForLevel(int level)
    {
        return Mathf.CeilToInt(baseEXP * Mathf.Pow(expGrowthRate, level));
    }

    int CalculateMaxExpForNextLevel(int level)
    {
        int totalEXP = 0;

        for (int i = 1; i < level; i++)
        {
            totalEXP += CalculateEXPForLevel(level);
        }

        return totalEXP;
    }

    void LevelUp()
    {
        // Increase max health
        // set to full health
        currentLevel++;
        AddSkillPoint();
        currentExperience = 0;
        maxExperience = CalculateMaxExpForNextLevel(currentLevel);
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
