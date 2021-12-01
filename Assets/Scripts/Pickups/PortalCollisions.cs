using System;
using Player;
using TreeEditor;
using UnityEngine;

namespace Pickups
{
    public class PortalCollisions : MonoBehaviour
    {
        private PlayerManager _pm;
        
        private void Start()
        {
            _pm = PlayerManager.Instance;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _pm.canTeleport = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _pm.canTeleport = false;
            }
        }
    }
}
