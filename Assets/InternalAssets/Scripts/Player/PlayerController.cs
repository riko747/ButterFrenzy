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
            
            playerRigidbody.AddForce(Vector2.up * PlayerData.JumpPower, ForceMode.Impulse);
            _bonusService.DecreaseBonus(Enums.BonusType.JumpBonus);
        }
        
        private void Move()
        {
            ClampPlayerPosition();

            if (_playerGravityState == Enums.PlayerGravityState.InAir) return;
            
            var moveX = Input.GetAxis("Horizontal");

            var velocity = playerRigidbody.velocity;
            velocity.x = moveX * PlayerData.MovementSpeed;
            velocity.z = PlayerData.MovementSpeed;
            playerRigidbody.velocity = velocity;

            playerRigidbody.AddForce(Physics.gravity, ForceMode.Force);
        }

        private void ClampPlayerPosition()
        {
            var playerPosition = playerRigidbody.position;
            playerPosition.x = Mathf.Clamp(playerPosition.x, PlayerData.ClampedMinPosition, PlayerData.ClampedMaxPosition);
            playerRigidbody.position = playerPosition;
        }

        private void OnCollisionExit() => _playerGravityState = Enums.PlayerGravityState.InAir;

        private void OnCollisionStay() => _playerGravityState = Enums.PlayerGravityState.OnGround;
    }
}
