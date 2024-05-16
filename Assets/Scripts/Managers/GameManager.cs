

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        Playing,
        Pause,
        GameOver
    }

    public GameState State { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        State = GameState.Playing;
    }

    public void SetGameState(GameState newState)
    {
        State = newState;
    }
}
