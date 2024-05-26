using System;

public class ExperienceManager : Singleton<ExperienceManager>
{
    public Action<int> OnExperienceChange;

    protected override void Awake()
    {
        base.Awake();
    }

    public void AddExperience(int amount)
    {
        OnExperienceChange?.Invoke(amount);
    }
}
