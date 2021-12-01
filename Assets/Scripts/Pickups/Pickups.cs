using UnityEngine;
using Player;

namespace Pickups {
    public class Pickups : MonoBehaviour
    {
        [SerializeField] private bool health;
        [SerializeField] private float amount;
        private PlayerManager _pm;
        
        private void Start()
        {
            _pm = PlayerManager.Instance;
        }

        public void CollectPickup()
        {
            if (health)
            {
                _pm.health += amount;
            }
            else
            {
                _pm.ammo += amount;
            }
        }
    }
}
