using System;
using UnityEngine;

namespace Entities.Enemies.Kuphyamp.Scripts
{
    [RequireComponent(typeof(SphereCollider))]
    public class TriggerScript : MonoBehaviour
    {
        public event Action<bool, Transform> TriggerChanged;
        private SphereCollider _collider;

        private void Awake()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.GetComponent<Player>()) return;
            TriggerChanged?.Invoke(true, other.transform);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.GetComponent<Player>()) return;
            TriggerChanged?.Invoke(false, other.transform);
        }

        public void ChangeRange(float range) => _collider.radius = range;
    }
}
