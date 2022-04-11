using InventorySystem.Scripts.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Environment.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Loot : MonoBehaviour
    {
        public ResourceItemData item;
        public int amount;
        [SerializeField] private float lifeTime = 100f;
        [SerializeField] private float spinTime = 2f;
        private Rigidbody _rigidbody;
        private float _timer;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            var randomForwardStrength = Random.Range(-1f, 1f);
            var randomRightStrength = Random.Range(-1f, 1f);
            var thisTransform = transform;
            var pullVector = thisTransform.forward * randomForwardStrength + thisTransform.right * randomRightStrength + Vector3.up * 2f;
            _rigidbody.AddForce(pullVector * 100);
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= lifeTime) Destroy();
            if (_timer >= spinTime) _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        }

        public void Destroy() => Destroy(gameObject);
    }
}
