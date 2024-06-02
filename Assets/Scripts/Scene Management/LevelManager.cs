using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Background Music")]
    [SerializeField] AudioClip tutorialMusic;
    [SerializeField] AudioClip baseLevelMusic;


    void OnEnable()
    {
        SceneManager.activeSceneChanged += HandleActiveSceneChange;
    }

    void OnDisable()
    {
        SceneManager.activeSceneChanged -= HandleActiveSceneChange;
    }

    void HandleActiveSceneChange(Scene current, Scene next)
    {
        GameObject startingPoint = GameObject.Find($"{next.name}StartingPoint");
        if (startingPoint != null)
        {
            PlayerSettings.Instance.SetPlayerLocation(startingPoint.transform);
        }
        else
        {
            Debug.Log("No starting point was detected in scene - " + next.name);
        }
        PlayerCombat.Instance.InitPlayerStatsUI();
        SpellCastHandler.Instance.SetCurrentElementalTypeUI();
        PlaySceneMusic(next.name);
    }

    void PlaySceneMusic(string sceneName)
    {
        if (sceneName == "Tutorial")
        {
            AudioManager.Instance.ChangeBackgroundMusic(tutorialMusic, .8f, true);
        }
        else if (sceneName == "BaseLevel")
        {
            AudioManager.Instance.ChangeBackgroundMusic(baseLevelMusic, .7f, true);
        }
    }
}
