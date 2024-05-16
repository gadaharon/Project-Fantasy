using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    [SerializeField] GameObject skillMenu;

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
            GameManager.Instance.SetGameState(GameManager.GameState.Pause);
        }
        else
        {
            currentMenu = null;
            GameManager.Instance.SetGameState(GameManager.GameState.Playing);
        }

        Time.timeScale = menu.activeSelf ? 0f : 1f;
        Character.Instance.SetCharacterCursorLook(!menu.activeSelf);
    }
}
