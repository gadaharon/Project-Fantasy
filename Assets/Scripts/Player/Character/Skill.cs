using System;


[Serializable]
public class Skill
{
    public string name;
    public int level;

    public Skill(string name, int level)
    {
        this.name = name;
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
