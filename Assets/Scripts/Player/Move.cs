using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Move : MonoBehaviour
    {
        private static readonly int Run = Animator.StringToHash("Run");
        private float _lookDirection;
        private static readonly int Jump = Animator.StringToHash("Jump");
        private const float MoveSpeed = 4f;
        private PlayerManager _pm;

        private void Start()
        {
            _pm = PlayerManager.Instance;
        }

        private void Update()
        {
            Handle_State();
        }

        private void Handle_State()
        {
            switch (_pm.State)
            {
                case PlayerManager.PlayerState.Run when _pm.isGrounded:
                    PlayerMove();
                    break;
                case PlayerManager.PlayerState.Jump when _pm.isGrounded:
                    PlayerJump();
                    _pm.isGrounded = false;
                    break;
            }
        }

        private void PlayerJump()
        {
            var jumpDirection = new Vector2(0.5f, 0) * _lookDirection;
            
            _pm.anim.SetBool(Jump, true);
            _pm.rb.AddForce((Vector2.up + jumpDirection) * 5f, ForceMode2D.Impulse);
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                _lookDirection = ctx.ReadValue<float>();
                _pm.ChangePlayerState(PlayerManager.PlayerState.Run);
            }
            else if (ctx.canceled)
            {
                _pm.anim.SetBool(Run, false);
                _pm.ChangePlayerState(PlayerManager.PlayerState.Idle);
            }
        }

        public void OnJump(InputAction.CallbackContext ctx)
        {
            if (ctx.started && _pm.isGrounded)
            {
                _pm.ChangePlayerState(PlayerManager.PlayerState.Jump);
            }
        }

        private void PlayerMove()
        {
            _pm.anim.SetBool(Run, true);
            transform.position += Vector3.right * (Time.deltaTime * MoveSpeed * _lookDirection);
            PlayerRotation();
        }

        private void PlayerRotation()
        {
            var playerTransform = transform;
            var rotation = playerTransform.rotation;
            
            playerTransform.eulerAngles = _lookDirection < 0 ?
                new Vector3(rotation.x, 180, rotation.z) :
                new Vector3(rotation.x, rotation.y, rotation.z);
        }
    }
}
