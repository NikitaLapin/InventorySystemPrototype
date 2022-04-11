using InventorySystem.Scripts.ScriptableObjects;
using UnityEngine;

namespace InventorySystem.Scripts
{
    [System.Serializable]
    public class DropItem
    {
        [SerializeField] private ResourceItemData itemData;
        [Range(0f, 1f)] [SerializeField] private float dropChance;
        [Range(0, 10)] [SerializeField] private int maximumDropAmount;

        public ResourceItemData ItemData => itemData;

        public int GetDropAmount()
        {
            var counter = 0;
            for (var i = 1; i <= maximumDropAmount; i++)
            {
                var randomNumber = Random.Range(0, 100);
                if (randomNumber <= (int) (dropChance * 100)) counter++;
            }

            return counter;
        }
    }
}
