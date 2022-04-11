using UnityEngine;

namespace InventorySystem.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory System/Items/Equipment")]
    public class EquipableItemData : ItemData
    {
        [SerializeField] private int horizontalSize;
        [SerializeField] private int verticalSize;

        public int HorizontalSize => horizontalSize;
        public int VerticalSize => verticalSize;
    }
}