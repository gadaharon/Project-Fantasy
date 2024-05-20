using System;

public enum GameState
{
    Playing,
    Pause,
    GameOver
}

public class GameManager : Singleton<GameManager>
{
    public static Action OnGameOver;

    public GameState State { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        State = GameState.Playing;
    }

    public static void TriggerGameOver()
    {
        OnGameOver?.Invoke();
    }

    public void SetGameState(GameState newState)
    {
        State = newState;
    }
}
