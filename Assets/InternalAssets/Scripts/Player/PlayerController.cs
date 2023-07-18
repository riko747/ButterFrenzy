using InternalAssets.Scripts.Other;
using UnityEngine;
using Zenject;

namespace InternalAssets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Inject] private IBonusService _bonusService;
        
        [SerializeField] private Rigidbody playerRigidbody;

        private Enums.PlayerState _playerState;

        private const float MovementSpeed = 10f;
        private const float ClampedMinPosition = -1.85f;
        private const float ClampedMaxPosition = 1.85f;
        private const float JumpPower = 20;

        private void Update()
        {
            Move();
            Jump();
        }

        private void Jump()
        {
            var canJump = Input.GetKeyDown(KeyCode.Space) && _playerState == Enums.PlayerState.OnGround && _bonusService.HasBonus(Enums.BonusType.JumpBonus);

            if (canJump)
            {
                playerRigidbody.AddForce(Vector2.up * JumpPower, ForceMode.Impulse);
                _bonusService.DecreaseBonus(Enums.BonusType.JumpBonus);
            }
        }
        
        private void Move()
        {
            ClampPlayerPosition();

            if (_playerState == Enums.PlayerState.InAir) return;
            
            var moveX = Input.GetAxis("Horizontal");

            var velocity = playerRigidbody.velocity;
            velocity.x = moveX * MovementSpeed;
            velocity.z = MovementSpeed;
            playerRigidbody.velocity = velocity;

            playerRigidbody.AddForce(Physics.gravity, ForceMode.Force);
        }

        private void ClampPlayerPosition()
        {
            var clampedPosition = playerRigidbody.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, ClampedMinPosition, ClampedMaxPosition);
            playerRigidbody.position = clampedPosition;
        }

        private void OnCollisionExit() => _playerState = Enums.PlayerState.InAir;

        private void OnCollisionStay() => _playerState = Enums.PlayerState.OnGround;
    }
}
