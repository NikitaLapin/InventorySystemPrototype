using System.Collections.Generic;
using Environment.Scripts;
using UnityEngine;

namespace InventorySystem.Scripts
{
    public class DeathDrop : MonoBehaviour
    {
        [SerializeField] private List<DropItem> allPossibleDrop;
        [SerializeField] private GameObject dropPrefab;
        public void Drop()
        {
            if (allPossibleDrop == null) return;
            foreach (var drop in allPossibleDrop)
            {
                var amount = drop.GetDropAmount();
                if (amount == 0) continue;
                
                var lootObject = Instantiate(dropPrefab);
                lootObject.transform.position = transform.position;
                var loot = lootObject.AddComponent<Loot>();
                loot.item = drop.ItemData;
                loot.amount = amount;
            }
        }
    }
}