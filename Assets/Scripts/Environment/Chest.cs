using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] GameObject chestClosedPrefab;
    [SerializeField] GameObject chestOpenPrefab;

    void Awake()
    {
        chestOpenPrefab.SetActive(false);
    }

    void OnEnable()
    {
        Loot.OnLootItems += OpenChest;
    }

    void OnDisable()
    {
        Loot.OnLootItems -= OpenChest;
    }

    void OpenChest(List<LootItem> items)
    {
        chestClosedPrefab.SetActive(false);
        chestOpenPrefab.SetActive(true);
    }


}
