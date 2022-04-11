using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(LootPicker))]
[RequireComponent(typeof(InventoryPresenter))]
public class Player : MonoBehaviour
{ 
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var enemy = hit.gameObject.GetComponent<Enemy>();
        if (enemy) enemy.TakeDamage(200);
    }
}
