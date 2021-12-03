using UnityEngine;

namespace Pickups
{
    public class Collision : MonoBehaviour
    {
        private Pickups _pickups;
        
        private void Start()
        {
            _pickups = GetComponent<Pickups>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag($"Player")) return;
            _pickups.CollectPickup();
            Destroy(gameObject);
        }
    }
}
