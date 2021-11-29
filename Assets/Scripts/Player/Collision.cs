using UnityEngine;

namespace Player
{
    public class Collision : PlayerManager
    {
        [SerializeField]
        private LayerMask groundLayer;

        private static readonly int Jump = Animator.StringToHash("Jump");

        private void Update()
        {
            CheckPlayerColliding();
        }

        private void CheckPlayerColliding()
        {
            if (isGrounded) return;
            TestCollision();
            if (isGrounded)
                HandleJumpState();
        }

        private void HandleJumpState()
        {
            anim.SetBool(Jump, false);
            ChangePlayerState(PlayerState.Run);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (isGrounded || !other.gameObject.CompareTag($"Obstacle")) return;
            isGrounded = true;
            HandleJumpState();
        }

        private void TestCollision()
        {
            var bounds = Cc.bounds;
            var boundHeight = bounds.extents.y - 1.22f;
            var rayCastHit = Physics2D.CapsuleCast(bounds.center, bounds.size,
                CapsuleDirection2D.Vertical, 0f, Vector2.down, boundHeight, groundLayer);
            isGrounded = rayCastHit.collider;
        }
        
        
    }
}
