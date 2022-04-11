using InventorySystem.ScriptableObjects.Inventories;
using UnityEngine;

public class InventoryPresenter : MonoBehaviour
{
    [SerializeField] private ResourceInventory resourceInventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) resourceInventory.ShowInventory();
    }
}