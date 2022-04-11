using InventorySystem.Scripts;
using UnityEngine;

[RequireComponent(typeof(DeathDrop))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp = 40;
    private DeathDrop _deathDrop;

    private void Start() => _deathDrop = GetComponent<DeathDrop>();
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0) Die();
    }

    private void Die()
    {
        _deathDrop.Drop();
        Destroy(gameObject);
    }
}
