using System.Collections.Generic;
using Environment.Scripts;
using InventorySystem.ScriptableObjects.Inventories;
using UnityEngine;

public class LootPicker : MonoBehaviour
{
    [SerializeField] private ResourceInventory resourceInventory;
    private List<Loot> _lootHistory = new List<Loot>();

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var loot = hit.gameObject.GetComponent<Loot>();
        if (loot && !_lootHistory.Contains(loot))
        {
            resourceInventory.AddNewItem(loot.item, loot.amount);
            _lootHistory.Add(loot);
            loot.Destroy();
        }
    }
}