using System.Collections.Generic;
using UnityEngine;

namespace Pickups
{
    public class Spawn : MonoBehaviour
    {
        [SerializeField] private List<GameObject> pickups = new List<GameObject>();
        
        private int RandomPickup()
        {
            var random = Random.Range(0, pickups.Count);
            return random;
        }
        
        public void SpawnPickup()
        {
            var location = transform.position;
            location.y += 1.0f;
            Instantiate(pickups[RandomPickup()], location, Quaternion.identity);
        }
    }
}
