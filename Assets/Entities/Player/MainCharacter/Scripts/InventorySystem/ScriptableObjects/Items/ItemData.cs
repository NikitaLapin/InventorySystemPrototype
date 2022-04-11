using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.Scripts.ScriptableObjects
{
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private string itemName;
        [SerializeField] private string description;
        [SerializeField] private Sprite icon;

        public string Id => id;
        public string ItemName => itemName;
        public string Description => description;
        public Sprite Icon => icon;
    }
}
