using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Attack : MonoBehaviour
    {
        private PlayerManager _pm;

        private void Start()
        {
            _pm = PlayerManager.Instance;
        }
        
        public void OnAttack(InputAction.CallbackContext ctx)
        {
            if (!ctx.started) return;
            if (_pm.ammo <= 0) return;
            _pm.Pool.Get();
            _pm.ammo -= 1.0f;
        }
    }
}
