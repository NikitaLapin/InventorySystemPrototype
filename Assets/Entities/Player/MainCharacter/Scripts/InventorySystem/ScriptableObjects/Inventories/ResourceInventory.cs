using System.Collections.Generic;
using InventorySystem.Scripts;
using InventorySystem.Scripts.ScriptableObjects;
using UnityEngine;

namespace InventorySystem.ScriptableObjects.Inventories
{
    [CreateAssetMenu(fileName = "New Resource Inventory", menuName = "Inventory System/Inventories/Resources Inventory")]
    public class ResourceInventory : ScriptableObject
    { 
        private readonly List<InventorySlot> _slots = new List<InventorySlot>();

        public void AddNewItem(ResourceItemData item, int amount)
        {
            foreach (var slot in _slots)
            {
                if (slot.Item == item)
                {
                    var isEnoughSpace = slot.TryIncreaseAmount(amount, out var extraAmount);
                    if (!isEnoughSpace) _slots.Add(new InventorySlot(item, extraAmount));
                    return;
                }
            }
            
            _slots.Add(new InventorySlot(item, amount));
        }

        public void ShowInventory()
        {
            foreach (var slot in _slots) Debug.Log($"{slot.Item.ItemName} : {slot.Amount}");
        }
    }
}
