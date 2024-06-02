using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Player Details")]
    [SerializeField] TextMeshProUGUI healthPotionAmount;
    [SerializeField] TextMeshProUGUI manaPotionAmount;
    [SerializeField] Bar playerHealthBar;
    [SerializeField] Bar playerManaBar;

    [Header("Player Magic")]
    [SerializeField] Image currentElementUI;

    [Header("Boss Health Bar")]
    [SerializeField] TextMeshProUGUI bossDisplayName;
    [SerializeField] GameObject bossHealthBarGO;


    public void UpdatePotionAmount(PotionType potionType, int amount)
    {
        if (potionType == PotionType.Health)
        {
            healthPotionAmount.text = amount.ToString();
        }
        else if (potionType == PotionType.Mana)
        {
            manaPotionAmount.text = amount.ToString();
        }
    }

    public void SetPlayerMaxHealthUI(float health)
    {
        playerHealthBar.SetMaxValue(health);
    }

    public void UpdatePlayerHealthUI(float health)
    {
        playerHealthBar.UpdateSliderValue(health);
    }

    public void SetPlayerMaxManaUI(float mana)
    {
        playerManaBar.SetMaxValue(mana);
    }

    public void UpdatePlayerManaUI(float mana)
    {
        playerManaBar.UpdateSliderValue(mana);
    }

    public void ToggleCurrentElementUI(bool isActive)
    {
        currentElementUI.gameObject.SetActive(isActive);
    }

    public void UpdateCurrentElementUISprite(Sprite sprite)
    {
        currentElementUI.sprite = sprite;
    }

    public void ToggleBossHealthBar(bool isActive)
    {
        bossHealthBarGO.SetActive(isActive);
    }

    public void SetBossDisplayName(string bossName)
    {
        bossDisplayName.text = bossName;
    }


}
