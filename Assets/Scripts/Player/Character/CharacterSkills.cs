using System.Collections.Generic;
using UnityEngine;

public class CharacterSkills
{
    Dictionary<string, Skill> skillsMap = new Dictionary<string, Skill>();

    public CharacterSkills(List<Skill> skills)
    {
        InitSkillsMap(skills);
    }

    void InitSkillsMap(List<Skill> skills)
    {
        foreach (var skill in skills)
        {
            skillsMap.Add(skill.name, skill);
        }
    }

    public Skill GetSkill(string name)
    {
        if (!skillsMap.ContainsKey(name))
        {
            Debug.Log("Invalid skill - " + name);
            return null;
        }

        return skillsMap[name];
    }
}
