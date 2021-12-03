using UnityEngine;

namespace Player
{
    public class Collision : MonoBehaviour
    {
        private PlayerManager _pm;
        private void Start()
        {
            _pm = PlayerManager.Instance;
        }

        private void HandleJumpState()
        {
            _pm.anim.SetBool(_pm.Jump, false);
            var posDif = (transform.position.x - _pm.playerPositionX);
            _pm.ChangePlayerState((posDif < 0.1f && posDif > -0.1f) ? PlayerManager.PlayerState.Idle : PlayerManager.PlayerState.Run);
            _pm.isGrounded = true;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!_pm.isGrounded && (other.gameObject.CompareTag($"Ground") || other.gameObject.CompareTag($"Enemy")))
            {
                HandleJumpState();
            }
        }
    }
}
