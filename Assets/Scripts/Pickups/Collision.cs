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
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag($"Player")) return;
            _pickups.CollectPickup();
            Destroy(gameObject);
        }
    }
}
