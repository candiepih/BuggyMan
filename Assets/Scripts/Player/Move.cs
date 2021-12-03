using System;
using Game_Manager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Move : MonoBehaviour
    {
        private const float MoveSpeed = 4f;
        private PlayerManager _pm;
        private GameManager _gm;

        private void Start()
        {
            _pm = PlayerManager.Instance;
            _gm = GameManager.Instance;
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
                    break;
                case PlayerManager.PlayerState.Idle:
                    break;
                case PlayerManager.PlayerState.Attack:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void PlayerJump()
        {
            var jumpDirection = new Vector2(0.6f, 0) * _pm.lookDirection;
            
            _pm.isGrounded = false;
            _pm.anim.SetBool(_pm.Jump, true);
            _pm.rb.AddForce((Vector2.up + jumpDirection) * 100f, ForceMode2D.Impulse);
            _pm.playerPositionX = transform.position.x;
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                _pm.lookDirection = ctx.ReadValue<float>();
                PlayerRotation();
                _pm.ChangePlayerState(PlayerManager.PlayerState.Run);
            }
            else if (ctx.canceled)
            {
                _pm.lookDirection = 0.0f;
                _pm.anim.SetBool(_pm.Run, false);
                _pm.ChangePlayerState(PlayerManager.PlayerState.Idle);
            }
        }

        public void OnJump(InputAction.CallbackContext ctx)
        {
            switch (ctx.started)
            {
                case true when _pm.canTeleport:
                    _gm.gameWon = true;
                    _gm.ChangeGameState(GameManager.GameState.GameOver);
                    break;
                case true:
                    _pm.ChangePlayerState(PlayerManager.PlayerState.Jump);
                    break;
            }
        }

        private void PlayerMove()
        {
            _pm.anim.SetBool(_pm.Run, true);
            transform.position += Vector3.right * (Time.deltaTime * MoveSpeed * _pm.lookDirection);
        }

        private void PlayerRotation()
        {
            var playerTransform = transform;
            var rotation = playerTransform.rotation;
            
            playerTransform.eulerAngles = _pm.lookDirection < 0 ?
                new Vector3(rotation.x, 180, rotation.z) :
                new Vector3(rotation.x, rotation.y, rotation.z);
        }
    }
}
