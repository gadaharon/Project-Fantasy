

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Potions")]
    [SerializeField] TextMeshProUGUI healthPotionAmount;
    [SerializeField] TextMeshProUGUI manaPotionAmount;

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
