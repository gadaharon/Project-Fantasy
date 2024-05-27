using System;

public enum SkillType
{
    Strength,
    Defense,
    Magic
}
[Serializable]
public class Skill
{
    public string name;
    public SkillType skillType;
    public int level;

    public Skill(string name, SkillType skillType, int level)
    {
        this.name = name;
        this.skillType = skillType;
        this.level = level;
    }

    public void SetSkillLevel(int level)
    {
        this.level = level;
    }
    public void IncreaseLevel()
    {
        this.level++;
    }

    public void DecreaseLevel()
    {
        if (this.level <= 0) { return; }

        this.level--;
    }
}
