using InternalAssets.Scripts.Other;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Player
{
    public class PlayerController : Player
    {
        [Inject] private IBonusService _bonusService;

        private Enums.PlayerGravityState _playerGravityState;

        private void FixedUpdate()
        {
            Jump();
            Move();
        }

        private void Jump()
        {
            var canJump = Input.GetKeyDown(KeyCode.Space) && _playerGravityState == Enums.PlayerGravityState.OnGround && _bonusService.HasBonus(Enums.BonusType.JumpBonus);

            if (!canJump) return;
            
            playerRigidbody.AddForce(Vector2.up * PlayerState.JumpPower, ForceMode.Impulse);
            _bonusService.DecreaseBonus(Enums.BonusType.JumpBonus);
        }
        
        private void Move()
        {
            ClampPlayerPosition();

            if (_playerGravityState == Enums.PlayerGravityState.InAir) return;
            
            var moveX = Input.GetAxis("Horizontal");

            var velocity = playerRigidbody.velocity;
            velocity.x = moveX * PlayerState.MovementSpeed;
            velocity.z = PlayerState.MovementSpeed;
            playerRigidbody.velocity = velocity;

            playerRigidbody.AddForce(Physics.gravity, ForceMode.Force);
        }

        private void ClampPlayerPosition()
        {
            var clampedPosition = playerRigidbody.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, PlayerState.ClampedMinPosition, PlayerState.ClampedMaxPosition);
            playerRigidbody.position = clampedPosition;
        }

        private void OnCollisionExit() => _playerGravityState = Enums.PlayerGravityState.InAir;

        private void OnCollisionStay() => _playerGravityState = Enums.PlayerGravityState.OnGround;
    }
}
