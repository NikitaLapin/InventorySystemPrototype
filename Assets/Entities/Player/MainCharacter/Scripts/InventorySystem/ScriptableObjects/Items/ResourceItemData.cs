using UnityEngine;

namespace InventorySystem.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Resource", menuName = "Inventory System/Items/Resource")]
    public class ResourceItemData : ItemData
    {
        [SerializeField] private int maximumAmountInSlot;
        public int MaximumAmountInSlot => maximumAmountInSlot;
    }
}
