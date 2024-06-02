using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    [SerializeField] GameObject skillMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverCanvas;

    GameObject currentMenu;


    void Update()
    {
        HandleMenuToggle();
    }

    void HandleMenuToggle()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ToggleMenu(skillMenu);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu(pauseMenu);
        }
    }

    public void ToggleMenu(GameObject menu)
    {
        if (currentMenu != null && currentMenu != menu)
        {
            currentMenu.SetActive(false);
        }

        menu.SetActive(!menu.activeSelf);

        if (menu.activeSelf)
        {
            currentMenu = menu;
            GameManager.Instance?.SetGameState(GameState.Pause);
        }
        else
        {
            currentMenu = null;
            GameManager.Instance?.SetGameState(GameState.Playing);
        }

        Time.timeScale = menu.activeSelf ? 0f : 1f;
        Character.Instance?.SetCharacterCursorLook(!menu.activeSelf);
    }

    public void ToggleGameOverMenu()
    {
        ToggleMenu(gameOverCanvas);
    }

    public void GameOverRestartButtonEvent()
    {
        GameManager.Instance.RestartGame();
    }

    public void QuitButtonEvent()
    {
        // ToggleMenu(currentMenu);
        // GameManager.Instance.ReturnToMainMenu();
        GameManager.Instance.QuitGame();
    }
}
