using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void RestartGame()
    {
        SetGameState(GameState.Playing);
        MenuManager.Instance.ToggleGameOverMenu();
        PlayerCombat.Instance.ResetPlayer();
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetGameState(GameState newState)
    {
        State = newState;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void StartGame()
    {
        LoadScene("Tutorial");
    }

    public void ReturnToMainMenu()
    {
        GameObject scenePersist = GameObject.Find("ScenePersist");
        if (scenePersist != null)
        {
            Destroy(scenePersist);
        }
        LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
